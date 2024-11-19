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
            return View(forklift);
        }

        // GET: Forklift/guid/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            Forklift forklift = await _context.Forklifts.FirstOrDefaultAsync(f => f.UniqueId == id);
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
            if (adapter.AdapterList == null)
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
            //forklift.PeriodicInspection.Id = forklift.UniqueId;
            foreach (var record in forklift.Adapter.AdapterList)
            {
                record.AdapterId = forklift.UniqueId;
                record.Number = forklift.Adapter.AdapterList.IndexOf(record) + 1;
            }


            if (ModelState.IsValid)
            {

                return Json(new { success = true, message = "Változások sikeresen elmentve." });
            }

            await GetModelNamesList();


            return View("Edit", forklift);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteAdapter(Guid id, Guid[] adapterList, Guid deleteId)
        {
            var adapter = await _context.AdapterInformation.FirstOrDefaultAsync(a => a.Id == id);

            var templist = new List<Forklift.AdapterRecord>();

            for (int i = 0; i < adapterList.Length; i++)
            {
                var adapterRecord = await _context.Adapters.Where(ar => ar.Id == adapterList[i] && ar.AdapterId == id).FirstOrDefaultAsync();
                templist.Add(adapterRecord);
            }
            templist.RemoveAll(x => x is null);

            templist.RemoveAll(ar => ar.Id == deleteId);
            templist = templist.OrderBy(ar => ar.Number).ToList();
            templist.ForEach(ar => ar.Number = templist.IndexOf(ar) + 1);

            adapter.AdapterList = templist;

            return PartialView("_AdapterTab", adapter);
        }

        [HttpPost]
        public async Task<IActionResult> AddAdapter(Guid id, Guid[] adapterList)
        {
            var adapter = await _context.AdapterInformation.FirstOrDefaultAsync(a => a.Id == id);
            var templist = new List<Forklift.AdapterRecord>();
            for (int i = 0; i < adapterList.Length; i++)
            {
                var adapterRecord = await _context.Adapters.Where(ar => ar.Id == adapterList[i] && ar.AdapterId == id).FirstOrDefaultAsync();
                templist.Add(adapterRecord);
            }
            templist.RemoveAll(x => x is null);

            templist = templist.OrderBy(ar => ar.Number).ToList();

            var newAdapter = new Forklift.AdapterRecord()
            {
                AdapterId = id
            };
            templist.Add(newAdapter);

            templist.ForEach(ar => ar.Number = templist.IndexOf(ar) + 1);

            adapter.AdapterList = templist;
            return PartialView("_AdapterTab", adapter);
        }


        private async Task GetModelNamesList()
        {
            List<ForkliftModelSelectorDTO> modelList = await _modelService.GetModelNamesAsync();

            List<SelectListItem> modelNames = modelList.Select(m => new SelectListItem(m.Manufacturer + " " + m.Type, m.Id.ToString())).ToList();

            ViewBag.ModelNames = modelNames;
        }
    }
}
