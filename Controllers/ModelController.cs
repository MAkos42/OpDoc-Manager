using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Data;
using OpDoc_Manager.Models;
using OpDoc_Manager.Service;

namespace OpDoc_Manager.Controllers
{
    public class ModelController : Controller
    {

        private readonly ILogger<ModelController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IForkliftModelsService _modelService;

        public ModelController(ILogger<ModelController> logger, ApplicationDbContext context, IForkliftModelsService modelService)
        {
            _logger = logger;
            _context = context;
            _modelService = modelService;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Models.DTO.ForkliftModelDTO> models = await _modelService.GetModelBaseInformationAsync();

            return View(models);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            Forklift.ModelInformation? model = await _context.ForkliftModels.FirstOrDefaultAsync(m => m.Id == id);
            if (model is null)
            {
                return NotFound("Model");
            }
            var electricEngine = await _context.Engines.OfType<Forklift.ElectricEngine>().FirstOrDefaultAsync(e => e.Id == model.EngineId);
            var icEngine = await _context.Engines.OfType<Forklift.InternalCombustionEngine>().FirstOrDefaultAsync(e => e.Id == model.EngineId);
            if (electricEngine is not null)
            {
                model.Engine = electricEngine;
            }
            if (icEngine is not null)
            {
                model.Engine = icEngine;
            }
            if (model.Engine is null)
            {
                return NotFound("Model Engine");
            }


            FillViewBag();

            return View(model);
        }

        public async Task<IActionResult> Create(Guid id)
        {
            Forklift.ModelInformation newModel = new();
            newModel.Id = Guid.Empty;

            FillViewBag();

            return await Task.FromResult(View("Edit", newModel));
        }

        [HttpPost]
        public async Task<IActionResult> SaveChanges(Forklift.ModelInformation model)
        {


            ModelState.Clear();
            TryValidateModel(model);

            if (ModelState.IsValid)
            {
                if (model.Id == Guid.Empty)
                {
                    _context.Add(model);
                }
                else
                {
                    _context.Update(model);
                }
                await _context.SaveChangesAsync();

                return Json(new { success = true, message = "Változások sikeresen elmentve." });
            }

            var errorList = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();

            FillViewBag();

            return BadRequest(new { success = false, message = "Mentés sikertelen!", errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
        }

        private void FillViewBag()
        {
            var dropdownAttributes = new { @class = "form-select" };
            var textboxAttributes = new { @class = "form-control", type = "text" };
            var numInputAttributes = new { @class = "form-control", type = "number" };
            var validationAttributes = new { @class = "text-danger" };

            ViewBag.DropdownAttributes = dropdownAttributes;
            ViewBag.TextboxAttributes = textboxAttributes;
            ViewBag.NumInputAttributes = numInputAttributes;
            ViewBag.ValidationAttributes = validationAttributes;

            ViewBag.NewElectricEngine = new Forklift.ElectricEngine();
            ViewBag.NewICEngine = new Forklift.InternalCombustionEngine();
        }
    }
}
