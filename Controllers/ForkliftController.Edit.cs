using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
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
            var electricEngine = await _context.Engines.OfType<Forklift.ElectricEngine>().FirstOrDefaultAsync(e => e.Id == model!.EngineId);
            var icEngine = await _context.Engines.OfType<Forklift.InternalCombustionEngine>().FirstOrDefaultAsync(e => e.Id == model!.EngineId);
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
                return NotFound("OpDocUser Manual");
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

            SetViewBagAttributes();
            ViewBag.MSZ9750CAT = Json(Forklift.PeriodicInspectionInformation.MSZ9750CATEGORIES);

            adapter.AdapterList.Select(x => x.Id).ToArray();

            return View(forklift);
        }
    }
}
