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
            if (forklift is null)
            {
                return NotFound("Forklift");
            }

            var model = await _context.ForkliftModels.Include(m => m.Engine).FirstOrDefaultAsync(m => m.Id == forklift.General.ModelId);
            if (forklift.General.Model is null)
            {
                return NotFound("Forklift Model");
            }
            var electricEngine = await _context.Engines.OfType<Forklift.ElectricEngine>().Where(e => e.Id == model!.EngineId).FirstOrDefaultAsync();
            var icEngine = await _context.Engines.OfType<Forklift.InternalCombustionEngine>().Where(e => e.Id == model!.EngineId).FirstOrDefaultAsync();
            if (forklift.General.Model.Engine is null)
            {
                return NotFound("Forklift Model Engine");
            }
            if (electricEngine is not null)
            {
                forklift.General.Model.Engine = electricEngine;
            }
            if (icEngine is not null)
            {
                forklift.General.Model.Engine = icEngine;
            }

            var operation = await _context.OperatorInformation.Include(oi => oi.LeaseInformation).FirstOrDefaultAsync(oi => oi.Id == id);
            if (forklift.Operator is null)
            {
                return NotFound("Operator Information");
            }
            if (forklift.Operator.LeaseInformation is null)
            {
                forklift.Operator.LeaseInformation = new Forklift.LeaseInformation();
            }

            var manual = await _context.UserManualInformation.FirstOrDefaultAsync(um => um.Id == id);
            if (forklift.UserManual is null)
            {
                return NotFound("User Manual");
            }

            var adapter = await _context.AdapterInformation.Include(ai => ai.AdapterList).FirstOrDefaultAsync(ai => ai.Id == id);
            if (forklift.Adapter is null)
            {
                return NotFound("Adapter Information");
            }
            if (adapter!.AdapterList is null)
            {
                adapter.AdapterList = new List<Forklift.AdapterRecord>();
            }

            adapter.AdapterList = adapter.AdapterList.OrderBy(ar => ar.Number).ToList();
            adapter.AdapterList.ForEach(ar => ar.Number = adapter.AdapterList.IndexOf(ar) + 1);

            var inspection = await _context.PeriodicInspectionInformation.Include(pi => pi.InspectionResults).Include(pi => pi.MaintenanceReports).FirstOrDefaultAsync(pi => pi.Id == id);
            if (forklift.PeriodicInspection is null)
            {
                return NotFound("Periodic Inspection");
            }
            if (forklift.PeriodicInspection.InspectionResults is null)
            {
                forklift.PeriodicInspection.InspectionResults = new List<Forklift.PeriodicInspectionResult>();
            }
            if (forklift.PeriodicInspection.MaintenanceReports is null)
            {
                forklift.PeriodicInspection.MaintenanceReports = new List<Forklift.MaintenanceReport>();
            }


            inspection!.InspectionResults = inspection.InspectionResults!.OrderBy(x => x.InspectionDate).ToList();

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
                record.ForkliftId = forklift.UniqueId;
                record.Number = forklift.Adapter.AdapterList.IndexOf(record) + 1;
            }

            forklift.General.Model = await _context.ForkliftModels.Where(m => m.Id == forklift.General.ModelId).Include(m => m.Engine).FirstOrDefaultAsync();

            if (!forklift.Operator.IsDifferentOperator)
            {
                forklift.Operator.Operator = forklift.Operator.Owner;
                forklift.Operator.OperatorAddress = forklift.Operator.OwnerAddress;
                forklift.Operator.LeaseInformation = null;
            }

            if (forklift.PeriodicInspection.InspectionCategory != Forklift.InspectionCategory.MANUFACTURER)
            {
                forklift.PeriodicInspection.ManufacturerInspectionId = null;
                forklift.PeriodicInspection.OperatorInspectionId = null;

                var staticData = Forklift.PeriodicInspectionInformation.MSZ9750CATEGORIES[forklift.PeriodicInspection.MSZ9750InspectionGroupId!.Value];
                forklift.PeriodicInspection.StructuralInspectionOpHours = staticData.StructuralInspectionOpHours;
                forklift.PeriodicInspection.StructuralInspectionMonths = staticData.StructuralInspectionMonths;
                forklift.PeriodicInspection.MainInspectionPeriodOpHours = staticData.MainInspectionPeriodOpHours;
                forklift.PeriodicInspection.MainInspectionPeriodMonths = staticData.MainInspectionPeriodMonths;

            }
            else
            {
                forklift.PeriodicInspection.MSZ9750InspectionGroupId = null;
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

            await GetModelNamesList();

            return BadRequest(new { success = false, message = "Mentés sikertelen!", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });

        }

        [HttpPost]
        public async Task<IActionResult> AddAdapter(Guid id, int number)
        {

            var newAdapter = new Forklift.AdapterRecord()
            {
                ForkliftId = id,
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
