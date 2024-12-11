using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OpDoc_Manager.Data;
using OpDoc_Manager.Models;
using OpDoc_Manager.Models.DTO;
using OpDoc_Manager.Service;

namespace OpDoc_Manager.Controllers
{
    [Authorize]
    public partial class ForkliftController : Controller
    {

        private readonly ILogger<ForkliftController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IForkliftModelsService _modelService;
        private readonly IForkliftIndexService _indexService;
        private readonly UserManager<OpDocUser> _userManager;

        public ForkliftController(ILogger<ForkliftController> logger, ApplicationDbContext context, IForkliftModelsService modelService, IForkliftIndexService indexService, UserManager<OpDocUser> userManager)
        {
            _logger = logger;
            _context = context;
            _modelService = modelService;
            _indexService = indexService;
            _userManager = userManager;
        }


        // GET: Forklift/guid
        public async Task<IActionResult> Index(Forklift forklift)
        {

            List<ForkliftIndexDTO> forklifts = await _indexService.GetIndexPageInformation();

            SetViewBagAttributes();

            return View(forklifts);
        }

        private void SetViewBagAttributes()
        {
            bool isAdmin = User.IsInRole("Admin");

            dynamic textInputAttributes = isAdmin ? new { @class = "form-control" } : new { @class = "form-control", @readonly = "" };
            dynamic numInputAttributes = isAdmin ? new { @class = "form-control", type = "number" } : new { @class = "form-control", type = "number", @readonly = "" };
            dynamic dateInputAttributes = isAdmin ? new { @class = "form-control", type = "date" } : new { @class = "form-control", type = "date", @readonly = "" };
            dynamic phoneInputAttributes = isAdmin ? new { @class = "form-control", type = "tel", placeholder = "+36 00 123 4567" } : new { @class = "form-control", type = "tel", placeholder = "+36 00 123 4567", @readonly = "" };

            dynamic differentOperatorAtt = isAdmin ? new { @class = "form-control different-operator-only" } : new { @class = "form-control different-operator-only", @readonly = "" };
            dynamic diffOpDateAttributes = isAdmin ? new { @class = "form-control different-operator-only", type = "date" } : new { @class = "form-control different-operator-only", type = "date", @readonly = "" };
            dynamic adapterRecordTextAtt = isAdmin ? new { @class = "form-control border-0 record-value" } : new { @class = "form-control border-0 record-value", @readonly = "" };
            dynamic adapterRecordNumAtt = isAdmin ? new { @class = "form-control border-0 record-value", type = "number" } : new { @class = "form-control border-0 record-value", type = "number", @readonly = "" };
            dynamic inspectionPeriodAtt = isAdmin ? new { @class = "form-control period-input", type = "number" } : new { @class = "form-control period-input", type = "number", @readonly = "" };

            dynamic dropdownAttributes = isAdmin ? new { @class = "form-select" } : new { @class = "form-select form-select-disabled", disabled = "" };
            dynamic select2Attributes = isAdmin ? new { @class = "form-select select2" } : new { @class = "form-select select2", disabled = "" };

            dynamic checkBoxAttributes = isAdmin ? new { @class = "form-check-input" } : new { @class = "form-check-input", disabled = "" };


            ViewBag.TextInputAttributes = textInputAttributes;
            ViewBag.NumInputAttributes = numInputAttributes;
            ViewBag.DateInputAttributes = dateInputAttributes;
            ViewBag.PhoneInputAttributes = phoneInputAttributes;

            ViewBag.DifferentOperatorAtt = differentOperatorAtt;
            ViewBag.DiffOpDateAttributes = diffOpDateAttributes;
            ViewBag.InspectionPeriodAtt = inspectionPeriodAtt;
            ViewBag.AdapterRecordTextAtt = adapterRecordTextAtt;
            ViewBag.AdapterRecordNumAtt = adapterRecordNumAtt;

            ViewBag.DropdownAttributes = dropdownAttributes;
            ViewBag.Select2Attributes = select2Attributes;

            ViewBag.CheckBoxAttributes = checkBoxAttributes;

            ViewBag.ValidationAttributes = new { @class = "text-danger" };

        }

        private async Task GetModelNamesList()
        {
            List<ForkliftModelSelectorDTO> modelList = await _modelService.GetModelNamesAsync();

            List<SelectListItem> modelNames = modelList.Select(m => new SelectListItem(m.Manufacturer + " " + m.Type, m.Id.ToString())).ToList();

            ViewBag.ModelNames = modelNames;
        }
    }
}
