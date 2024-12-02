using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddInspection(Forklift.PeriodicInspectionResult result)
        {
            result.Id = Guid.Empty;

            //result.Technician = User.Identity.Name;
            result.Technician = "tempValue";

            Forklift.PeriodicInspectionInformation? inspectionInformaton = await _context.PeriodicInspectionInformation.FirstOrDefaultAsync(i => i.Id == result.ForkliftId);
            if (inspectionInformaton is null)
            {
                return BadRequest(new { success = false, message = "Ment�s sikertelen!", errors = "A megadott targonca nem l�tezik!" });
            }

            if (result.HasPassedInspection && result.Type != Forklift.InspectionType.INSPECTION)
            {
                inspectionInformaton.LastInspectionDate = result.InspectionDate;
                inspectionInformaton.NextInspectionOpHours = inspectionInformaton.NextInspectionOpHours + inspectionInformaton.StructuralInspectionOpHours;
                inspectionInformaton.NextInspectionDate = inspectionInformaton.NextInspectionDate.AddMonths(inspectionInformaton.StructuralInspectionMonths);
            }

            ModelState.Clear();
            TryValidateModel(result);

            if (ModelState.IsValid)
            {
                _context.PeriodicInspectionInformation.Update(inspectionInformaton);

                _context.periodicInspections.Add(result);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Vizsg�lat sikeresen hozz�adva." });
            }

            var errorList = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            await GetModelNamesList();

            return BadRequest(new { success = false, message = "Ment�s sikertelen!", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
    }
}
