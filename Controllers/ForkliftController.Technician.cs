using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Technician(Guid id)
        {
            var inspection = await _context.PeriodicInspectionInformation.FirstOrDefaultAsync(ii => ii.Id == id);
            if (inspection is null)
            {
                return NotFound("Periodic Inspection Information");
            }

            return View(inspection);
        }
    }
}
