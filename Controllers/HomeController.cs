using Microsoft.AspNetCore.Mvc;
using OpDoc_Manager.Data;
using OpDoc_Manager.Data.Service;
using OpDoc_Manager.Models;
using System.Diagnostics;

namespace OpDoc_Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IForkliftModelsService _modelsService;

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
            _context.ForkliftModels.RemoveRange(_context.ForkliftModels);
            Forklift.ModelInformation testModel = new Forklift.ModelInformation
            {
                Manufacturer = "CAT",
                Type = "DP20-35N3",

                LiftMechanism = new Forklift.LiftMechanism
                {
                    LoadCapacity = 3.5,
                    FreeLift = 145,
                    NominalLiftHeight = 3300,
                    MaxLiftHeight = 3445,
                    MaxHeightMaxLoad = 2.4,
                    LiftSpeedUnloaded = 0.41,
                    LiftSpeedLoaded = 0.43,
                    MastForwardTiltAngle = 6,
                    MastBackwardTiltAngle = 10
                },

                RoadInformation = new Forklift.RoadInformation
                {
                    Width = 1290,
                    Length = 3865,
                    HeightTransportPosition = 2300,
                    HeightMastLowered = 2300,
                    HeightMastRaised = 4355,
                    OuterTurningCircle = 2440,
                    InnerTurningCircle = 500,
                    Wheelbase = 1700,
                    TrackWidthFront = 1060,
                    TrackWidthBack = 980,
                    RideHeight = 120,
                    TopSpeedWithLoad = 16.5,
                    TopSpeedWithoutLoad = 18.0,
                    TractiveForce = 15000,
                    FrontWheelCount = 2,
                    BackWheelCount = 2,
                    FrontWheelSize = "250-15-12PR",
                    BackWheelSize = "6.5-10-10PR",
                    FrontWheelPressure = 2.3,
                    BackWheelPressure = 2.5,
                    OperationalWeight = 4820,
                    BatteryWeight = 0,
                    BreakingForce = 30000,
                    ParkingBreakForce = 40000
                },

                Engine = new Forklift.InternalCombustionEngine
                {
                    EngineType = Forklift.EngineType.ICE,
                    Manufacturer = "",
                    Type = "D04EG",
                    RatedOutput = 36.0,
                    CylinderVolume = 3331,
                    FuelCapacity = 10
                }
            };
            _context.ForkliftModels.Add(testModel);
            _context.SaveChanges();


            //_context.Forklifts.RemoveRange(_context.Forklifts);

            Forklift test = new Forklift
            {
                UniqueId = new Guid(),
                General = new Forklift.GeneralInformation
                {
                    Name = "TestForklift1",
                    Manufacturer = "CAT",
                    Model = "DP20-35N3",
                    OperatorType = Forklift.OperatorType.SEATED,
                    ManufacturingYear = 2022,
                    ProductionNumber = "CTZXAB1222001",
                    ForkliftType = Forklift.ForkliftType.LIFT,
                    PowerSource = Forklift.PowerSource.DIESEL,
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
                },
                Technical = new Forklift.TechnicalInformation
                {
                    Model = testModel,
                    EngineProductionNumber = "TEST0101"
                }
            };

            _context.Forklifts.Add(test);
            _context.OperatorInformation.Add(test.Operator);
            if (test.Operator.LeaseInformation != null)
                _context.LeaseInformation.Add(test.Operator.LeaseInformation);
            _context.UserManualInformation.Add(test.UserManual);
            _context.TechnicalInformation.Add(test.Technical);
            _context.SaveChanges();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}