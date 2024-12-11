using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> SetInactive(Guid id)
        {
            Forklift? forklift = await _context.Forklifts.FirstOrDefaultAsync(f => f.UniqueId == id);
            if (forklift == null)
            {
                return BadRequest(new { success = false, message = "T�rl�s sikertelen!", error = "A megadott tartgonca nem l�tezik!" });
            }

            forklift.IsActive = false;

            _context.Forklifts.Update(forklift);

            await _context.SaveChangesAsync();

            return Json(new { success = true, message = "A targonca sikeresen t�r�lve a rendszerb�l!" });
        }
    }
}
