using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SaveChanges(Forklift forklift)
        {
            forklift.Operator.Id = forklift.UniqueId;
            forklift.UserManual.Id = forklift.UniqueId;
            forklift.Adapter.Id = forklift.UniqueId;
            forklift.PeriodicInspection.Id = forklift.UniqueId;
            foreach (var record in forklift.Adapter.AdapterList)
            {
                record.ForkliftId = forklift.UniqueId;
                record.Number = forklift.Adapter.AdapterList.IndexOf(record) + 1;
            }

            Forklift.ModelInformation? model = await _context.ForkliftModels.Include(m => m.Engine).FirstOrDefaultAsync(m => m.Id == forklift.General.ModelId);

            if (model is null)
            {
                return BadRequest(new { success = false, message = "Ment�s sikertelen!", errors = "A megadott targonca modell nem tal�lhat�!" });
            }

            forklift.General.Model = model;

            if (!forklift.Operator.IsDifferentOperator)
            {
                forklift.Operator.Operator = forklift.Operator.Owner;
                forklift.Operator.OperatorAddress = forklift.Operator.OwnerAddress;
                forklift.Operator.LeaseInformation = null;
            }

            if (forklift.PeriodicInspection.InspectionCategory != Forklift.InspectionCategory.MANUFACTURER)
            {
                forklift.PeriodicInspection.ManufacturerInspectionId = null;
                forklift.PeriodicInspection.OperatorInspectionId = null;

                var staticData = Forklift.PeriodicInspectionInformation.MSZ9750CATEGORIES[forklift.PeriodicInspection.MSZ9750InspectionGroupId!.Value];
                forklift.PeriodicInspection.StructuralInspectionOpHours = staticData.StructuralInspectionOpHours;
                forklift.PeriodicInspection.StructuralInspectionMonths = staticData.StructuralInspectionMonths;
                forklift.PeriodicInspection.MainInspectionPeriodOpHours = staticData.MainInspectionPeriodOpHours;
                forklift.PeriodicInspection.MainInspectionPeriodMonths = staticData.MainInspectionPeriodMonths;

            }
            else
            {
                forklift.PeriodicInspection.MSZ9750InspectionGroupId = null;
            }

            if (forklift.UniqueId == Guid.Empty)
            {
                forklift.PeriodicInspection.OperatingHours = 0;
                forklift.PeriodicInspection.NextInspectionOpHours = forklift.PeriodicInspection.StructuralInspectionOpHours;
                forklift.PeriodicInspection.LastInspectionDate = forklift.General.EntryIntoService;
                forklift.PeriodicInspection.NextInspectionDate = forklift.General.EntryIntoService.AddMonths(forklift.PeriodicInspection.StructuralInspectionMonths);
            }

            ModelState.Clear();
            TryValidateModel(forklift);

            if (ModelState.IsValid)
            {
                if (forklift.UniqueId == Guid.Empty)
                {
                    _context.Add(forklift);
                }
                else
                {
                    _context.Update(forklift);
                }
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "V�ltoz�sok sikeresen elmentve." });
            }

            var errorList = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            await GetModelNamesList();

            return BadRequest(new { success = false, message = "Ment�s sikertelen!", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

        }
    }
}
