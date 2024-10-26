using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Data;
using OpDoc_Manager.Data.Service;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public class ViewController : Controller
    {

        private readonly ILogger<ViewController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IForkliftModelsService _modelService;

        public ViewController(ILogger<ViewController> logger, ApplicationDbContext context, IForkliftModelsService modelService)
        {
            _logger = logger;
            _context = context;
            _modelService = modelService;
        }


        // GET: View/guid
        public async Task<IActionResult> Index(Guid id)
        {
            var forklift = await _context.Forklifts
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (forklift == null)
            {
                return NotFound();
            }

            return View(forklift);
        }

        // GET: View/guid/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var forklift = await _context.Forklifts.FirstOrDefaultAsync(f => f.UniqueId == id);
            if (forklift == null)
            {
                return NotFound("Forklift");
            }
            var forkliftModel = await _context.ForkliftModels.FirstOrDefaultAsync(m => m.Id == forklift.General.ModelId);
            if (forkliftModel == null)
            {
                return NotFound("Forklift Model");
            }
            var operatorInfo = await _context.OperatorInformation.FirstOrDefaultAsync(oi => oi.Id == id);
            if (operatorInfo == null)
            {
                return NotFound("Operator Information");
            }
            var tempLeaseInformation = new Forklift.LeaseInformation();
            if (operatorInfo.LeaseInformation == null)
            {
                forklift.Operator.LeaseInformation = tempLeaseInformation;
            }
            var userManualInfo = await _context.UserManualInformation.FirstOrDefaultAsync(um => um.Id == id);
            if (userManualInfo == null)
            {
                return NotFound("User Manual");
            }
            var adapterInfo = await _context.AdapterInformation.FirstOrDefaultAsync(ai => ai.Id == id);
            if (adapterInfo == null)
            {
                return NotFound("Adapter Information");
            }
            var adapters = await _context.Adapters.Where(a => a.AdapterId == id).OrderBy(a => a.OrderId).ToListAsync();
            if (adapters.Count == 0)
            {
                return NotFound("Adapter Records");
            }

            List<ForkliftModelSelectorDTO> modelList = await _modelService.GetModelNamesAsync();

            List<SelectListItem> modelNames = modelList.Select(m => new SelectListItem(m.Manufacturer + " " + m.Type, m.Id.ToString())).ToList();

            ViewBag.ModelNames = modelNames;

            return View(forklift);
        }


        private bool ForkliftExists(string id)
        {
            return _context.Forklifts.Any(e => e.UniqueId == Guid.Parse(id));
        }
    }
}
