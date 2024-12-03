using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpDoc_Manager.Data;
using OpDoc_Manager.Models;
using OpDoc_Manager.Models.DTO;
using OpDoc_Manager.Service;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {

        private readonly ILogger<ForkliftController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IForkliftModelsService _modelService;

        public ForkliftController(ILogger<ForkliftController> logger, ApplicationDbContext context, IForkliftModelsService modelService)
        {
            _logger = logger;
            _context = context;
            _modelService = modelService;
        }


        // GET: Forklift/guid
        public async Task<IActionResult> Index(Forklift forklift)
        {

            Forklift[] forklifts = _context.Forklifts.ToArray();

            List<ForkliftModelSelectorDTO> modelList = await _modelService.GetModelNamesAsync();

            ViewBag.ModelList = modelList;

            return View(forklifts);
        }


        private async Task GetModelNamesList()
        {
            List<ForkliftModelSelectorDTO> modelList = await _modelService.GetModelNamesAsync();

            List<SelectListItem> modelNames = modelList.Select(m => new SelectListItem(m.Manufacturer + " " + m.Type, m.Id.ToString())).ToList();

            ViewBag.ModelNames = modelNames;
        }
    }
}
