using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Data;
using OpDoc_Manager.Data.Service;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public class ForkliftController : Controller
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
            return await Task.FromResult(View(forklift));
        }

        // GET: Forklift/guid/Edit
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            Forklift? forklift = await _context.Forklifts.FirstOrDefaultAsync(f => f.UniqueId == id);
            if (forklift == null)
            {
                return NotFound("Forklift");
            }

            var general = await _context.ForkliftModels.FirstOrDefaultAsync(m => m.Id == forklift.General.ModelId);
            if (forklift.General.Model == null)
            {
                return NotFound("Forklift Model");
            }

            var operation = await _context.OperatorInformation.Include(oi => oi.LeaseInformation).FirstOrDefaultAsync(oi => oi.Id == id);
            if (forklift.Operator == null)
            {
                return NotFound("Operator Information");
            }

            var tempLeaseInformation = new Forklift.LeaseInformation();
            if (forklift.Operator.LeaseInformation == null)
            {
                forklift.Operator.LeaseInformation = tempLeaseInformation;
            }

            var manual = await _context.UserManualInformation.FirstOrDefaultAsync(um => um.Id == id);
            if (forklift.UserManual == null)
            {
                return NotFound("User Manual");
            }

            var adapter = await _context.AdapterInformation.Include(ai => ai.AdapterList).FirstOrDefaultAsync(ai => ai.Id == id);
            if (forklift.Adapter == null)
            {
                return NotFound("Adapter Information");
            }
            if (adapter!.AdapterList == null)
            {
                adapter.AdapterList = new List<Forklift.AdapterRecord>();
            }

            adapter.AdapterList = adapter.AdapterList.OrderBy(ar => ar.Number).ToList();
            adapter.AdapterList.ForEach(ar => ar.Number = adapter.AdapterList.IndexOf(ar) + 1);

            var inspection = await _context.PeriodicInspectionInformation.FirstOrDefaultAsync(pi => pi.Id == id);
            if (forklift.PeriodicInspection == null)
            {
                return NotFound("Periodic Inspection");
            }


            await GetModelNamesList();

            ViewBag.MSZ9750CAT = Json(Forklift.PeriodicInspectionInformation.MSZ9750CATEGORIES);

            adapter.AdapterList.Select(x => x.Id).ToArray();

            return View(forklift);
        }

        [HttpPost]
        public async Task<IActionResult> SaveChanges(Forklift forklift)
        {
            forklift.Operator.Id = forklift.UniqueId;
            forklift.UserManual.Id = forklift.UniqueId;
            forklift.Adapter.Id = forklift.UniqueId;
            forklift.PeriodicInspection.Id = forklift.UniqueId;
            foreach (var record in forklift.Adapter.AdapterList)
            {
                record.AdapterId = forklift.UniqueId;
                record.Number = forklift.Adapter.AdapterList.IndexOf(record) + 1;
            }

            forklift.General.Model = await _context.ForkliftModels.Where(m => m.Id == forklift.General.ModelId).Include(m => m.Engine).FirstOrDefaultAsync();

            if (!forklift.Operator.IsDifferentOperator)
            {
                forklift.Operator.Operator = forklift.Operator.Owner;
                forklift.Operator.OperatorAddress = forklift.Operator.OwnerAddress;
                forklift.Operator.LeaseInformation = null;
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

                return Json(new { success = true, message = "Változások sikeresen elmentve." });
            }

            var errorList = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            return BadRequest(new { success = false, message = "Validation failed.", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        [HttpPost]
        public async Task<IActionResult> AddAdapter(Guid id, int number)
        {

            var newAdapter = new Forklift.AdapterRecord()
            {
                AdapterId = id,
                Number = number
            };

            List<Forklift.AdapterRecord?> returnList = new();

            for (int i = 0; i < number - 1; i++)
            {
                returnList.Add(null);
            }
            returnList.Add(newAdapter);

            return await Task.FromResult(PartialView("_AdapterRecord", returnList));
        }


        private async Task GetModelNamesList()
        {
            List<ForkliftModelSelectorDTO> modelList = await _modelService.GetModelNamesAsync();

            List<SelectListItem> modelNames = modelList.Select(m => new SelectListItem(m.Manufacturer + " " + m.Type, m.Id.ToString())).ToList();

            ViewBag.ModelNames = modelNames;
        }
    }
}
