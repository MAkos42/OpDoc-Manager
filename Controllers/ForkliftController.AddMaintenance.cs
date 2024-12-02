using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMaintenance(Forklift.MaintenanceReport report)
        {
            report.Id = Guid.Empty;

            Forklift.PeriodicInspectionInformation? inspectionInformaton = await _context.PeriodicInspectionInformation.FirstOrDefaultAsync(i => i.Id == report.ForkliftId);
            if (inspectionInformaton is null)
            {
                return BadRequest(new { success = false, message = "Ment�s sikertelen!", errors = "A megadott targonca nem l�tezik!" });
            }

            ModelState.Clear();
            TryValidateModel(report);

            if (ModelState.IsValid)
            {
                _context.MaintenanceReports.Add(report);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Jav�t�s/Csere sikeresen hozz�adva." });
            }

            var errorList = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            await GetModelNamesList();

            return BadRequest(new { success = false, message = "Ment�s sikertelen!", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
    }
}
