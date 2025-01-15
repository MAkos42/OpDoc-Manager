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
            if (forklift.Adapter.AdapterList is null)
            {
                return BadRequest(new { success = false, message = "Mentés sikertelen!", error = "Adapter megadása kötelezõ!" });
            }
            forklift.PeriodicInspection.Id = forklift.UniqueId;
            foreach (var record in forklift.Adapter.AdapterList)
            {
                record.ForkliftId = forklift.UniqueId;
                record.Number = forklift.Adapter.AdapterList.IndexOf(record) + 1;
            }

            List<Guid> adapterIds = forklift.Adapter.AdapterList.Select(x => x.Id).ToList();

            Forklift.ModelInformation? model = await _context.ForkliftModels.Include(m => m.Engine).FirstOrDefaultAsync(m => m.Id == forklift.General.ModelId);

            if (model is null)
            {
                return BadRequest(new { success = false, message = "Mentés sikertelen!", error = "A megadott targonca modell nem található!" });
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
                bool isCreated = false;

                if (forklift.UniqueId == Guid.Empty)
                {
                    _context.Add(forklift);
                    isCreated = true;
                }
                else
                {
                    _context.Update(forklift);

                    _context.Adapters.RemoveRange(await _context.Adapters.Where(a => a.ForkliftId == forklift.UniqueId && !adapterIds.Contains(a.Id)).ToListAsync());

                }
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = isCreated ? "Targonca sikeresen felvéve a rendszerbe." : "Változások sikeresen elmentve." });
            }

            var errorList = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            await GetModelNamesList();

            return BadRequest(new { success = false, message = "Mentés sikertelen!", error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

        }
    }
}
