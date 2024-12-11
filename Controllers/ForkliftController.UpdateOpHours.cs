using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;
using OpDoc_Manager.Models.DTO;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
        [HttpPost]
        [Authorize(Roles = "Operator")]
        public async Task<IActionResult> UpdateOpHours(UpdateOpHoursDTO update)
        {
            Forklift.PeriodicInspectionInformation? inspectionInformaton = await _context.PeriodicInspectionInformation.FirstOrDefaultAsync(i => i.Id == update.ForkliftId);
            if (inspectionInformaton is null)
            {
                return BadRequest(new { success = false, message = "Mentés sikertelen!", error = "A megadott targonca nem létezik!" });
            }
            if (inspectionInformaton.OperatingHours != update.Old)
            {
                return BadRequest(new { success = false, message = "Mentés sikertelen!", error = "A régi üzemóra érték nem egyezett az adatbázisban tároltakkal!<br>Frissítse az ablakot a hiba elhárításhoz!" });
            }


            inspectionInformaton.OperatingHours = update.New;

            if (ModelState.IsValid)
            {
                _context.PeriodicInspectionInformation.Update(inspectionInformaton);

                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Üzemóra szám sikeresen frissítve." });
            }

            var errorList = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            return BadRequest(new { success = false, message = "Mentés sikertelen!", error = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }
    }
}
