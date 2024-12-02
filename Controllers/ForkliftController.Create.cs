using Microsoft.AspNetCore.Mvc;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Create(Guid id)
        {
            Forklift forklift = new();
            forklift.UniqueId = Guid.Empty;

            await GetModelNamesList();

            ViewBag.MSZ9750CAT = Json(Forklift.PeriodicInspectionInformation.MSZ9750CATEGORIES);

            return View("Edit", forklift);
        }
    }
}
