using Microsoft.AspNetCore.Mvc;
using OpDoc_Manager.Data;
using OpDoc_Manager.Models;
using System.Diagnostics;

namespace OpDoc_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //if (_context.Forklifts.Count() == 0)
            GenerateTestData();

            Forklift[] forklifts = _context.Forklifts.ToArray();
            return View(forklifts);
        }

        private void GenerateTestData()
        {
            /*_context.ForkliftModels.RemoveRange(_context.ForkliftModels);
            Forklift.TechnicalInformation testType = new Forklift.TechnicalInformation
            {
                Manufacturer = "CAT",
                Model = "DP20-35N3"
            };*/


            _context.Forklifts.RemoveRange(_context.Forklifts);

            Forklift test = new Forklift
            {
                UniqueId = new Guid(),
                General = new Forklift.GeneralInformation
                {
                    Name = "TestForklift1",
                    Manufacturer = "CAT",
                    Model = "DP20-35N3",
                    ControlMethod = Forklift.ControlMethod.SEAT,
                    ManufacturingYear = 2022,
                    ProductionNumber = "CTZXAB1222001",
                    OperationType = Forklift.OperationType.LIFT,
                    EnergySource = Forklift.EnergySource.DIESEL,
                    EntryIntoService = new DateOnly(2022, 10, 11)
                },
                Operator = new Forklift.OperatorInformation
                {
                    Owner = "Targonca Operations Kft.",
                    OwnerAddress = "3501 Miskolc, Tesztpálya út. 31.",
                    IsDifferentOperator = false,
                    OperationArea = "Raktár A1",
                    UserName = "Tóth Béla",
                    UserPosition = "Targoncavezetõ",
                    TechnicianName = "Székely József",
                    TechnicianPosition = "Targoncaszerelõ",
                    ForkliftAdministrator = "Ferenczy Sándor",
                    ForkliftAdminPosition = "Emelõgép-ügyintézõ",
                    ForkliftAdminContact = "+36201234567"
                },
                UserManual = new Forklift.UserManualInformation
                {
                    DateOfTransfer = new DateOnly(2022, 10, 14),
                    IsOnlineManual = true,
                    ManualWebsite = "https://www.niketrans.hu/site/assets/files/1081/chbc2037-d.pdf",
                    SupplierType = Forklift.UserManualInformation.Supplier.DISTRIBUTOR,
                    SupplierSigneeName = "Pálffy János",
                    SupplierSigneePosition = "Adásvételi technikus",
                    RecipientType = Forklift.UserManualInformation.Recipient.CUSTOMER,
                    RecipientSigneeName = "Ferenczy Sándor",
                    RecipientSigneePosition = "Emelõgép-ügyintézõ"
                }
            };

            _context.Forklifts.Add(test);
            _context.OperatorInformation.Add(test.Operator);
            if (test.Operator.LeaseInformation != null)
                _context.LeaseInformation.Add(test.Operator.LeaseInformation);
            _context.UserManualInformation.Add(test.UserManual);
            _context.SaveChanges();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}