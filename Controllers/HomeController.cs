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
            if (_context.Forklifts.Count() == 0)
                GenerateTestData();

            Forklift[] forklifts = _context.Forklifts.ToArray();
            return View(forklifts);
        }

        private void GenerateTestData()
        {

            _context.ForkliftModels.RemoveRange(_context.ForkliftModels);
            Forklift.ModelInformation testModel1 = new Forklift.ModelInformation
            {
                Manufacturer = "CAT",
                Type = "DP35N3-3300S",
                OperatorType = Forklift.OperatorType.SEATED,
                OperationMode = Forklift.OperationMode.LIFT,
                PowerSource = Forklift.PowerSource.DIESEL,

                LiftMechanism = new Forklift.LiftMechanism
                {
                    LoadCapacity = 3.5,
                    FreeLift = 145,
                    NominalLiftHeight = 3300,
                    MaxLiftHeight = 3445,
                    MaxHeightMaxLoad = 3.5,
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
                    InnerTurningCircle = 780,
                    Wheelbase = 1700,
                    TrackWidthFront = 1060,
                    TrackWidthBack = 980,
                    GroundClearance = 135,
                    TopSpeedWithLoad = 16.5,
                    TopSpeedWithoutLoad = 18.0,
                    DrawbarPull = 15900,
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

            Forklift.ModelInformation testModel2 = new Forklift.ModelInformation
            {
                Manufacturer = "CAT",
                Type = "EP25N-3300S",
                OperatorType = Forklift.OperatorType.SEATED,
                OperationMode = Forklift.OperationMode.LIFT,
                PowerSource = Forklift.PowerSource.DIESEL,

                LiftMechanism = new Forklift.LiftMechanism
                {
                    LoadCapacity = 2.5,
                    FreeLift = 100,
                    NominalLiftHeight = 3300,
                    MaxLiftHeight = 3400,
                    MaxHeightMaxLoad = 2.5,
                    LiftSpeedUnloaded = 0.5,
                    LiftSpeedLoaded = 0.65,
                    MastForwardTiltAngle = 6,
                    MastBackwardTiltAngle = 8
                },

                RoadInformation = new Forklift.RoadInformation
                {
                    Width = 1190,
                    Length = 3600,
                    HeightTransportPosition = 2145,
                    HeightMastLowered = 2300,
                    HeightMastRaised = 4355,
                    OuterTurningCircle = 2064,
                    InnerTurningCircle = 160,
                    Wheelbase = 1730,
                    TrackWidthFront = 985,
                    TrackWidthBack = 970,
                    GroundClearance = 122,
                    TopSpeedWithLoad = 20.0,
                    TopSpeedWithoutLoad = 20.0,
                    DrawbarPull = 9700,
                    FrontWheelCount = 2,
                    BackWheelCount = 2,
                    FrontWheelSize = "23x9-10",
                    BackWheelSize = "18x7-8",
                    FrontWheelPressure = 2.3,
                    BackWheelPressure = 2.5,
                    OperationalWeight = 4700,
                    BatteryWeight = 1893,
                    BreakingForce = 30000,
                    ParkingBreakForce = 40000
                },

                Engine = new Forklift.ElectricEngine
                {
                    EngineType = Forklift.EngineType.ELECTRIC,

                    BatteryType = "",
                    BatteryManufacturer = "",
                    NominalBatteryCapacity = 775,
                    BatteryVoltage = 80,
                    BatteryCellCount = 12,

                    EngineManufacturer = "",
                    EngineOutput = 8.0,
                    EngineRPM = 2000,

                    InverterManufacturer = "",
                    InverterType = "",
                    InverterPerformance = "",

                    FrequencyConverterManufacturer = "",
                    FrequencyConverterType = "",
                    FrequencyConverterPerformance = ""

                }
            };

            _context.ForkliftModels.Add(testModel1);
            _context.ForkliftModels.Add(testModel2);
            _context.SaveChanges();


            _context.Forklifts.RemoveRange(_context.Forklifts);

            Forklift test = new Forklift
            {
                General = new Forklift.GeneralInformation
                {
                    Name = "TestForklift1",
                    ManufacturingYear = 2022,
                    ProductionNumber = "CTZXAB1222001",

                    Model = testModel1,
                    EngineProductionNumber = "TEST0101",

                    EntryIntoService = new DateOnly(2022, 10, 11)
                },
                Operator = new Forklift.OperatorInformation
                {
                    Owner = "Targonca Operations Kft.",
                    OwnerAddress = "3501 Miskolc, Tesztp�lya �t. 31.",
                    Operator = "Targonca Operations Kft.",
                    OperatorAddress = "3501 Miskolc, Tesztp�lya �t. 31.",
                    IsDifferentOperator = false,
                    OperationArea = "Rakt�r A1",
                    UserName = "T�th B�la",
                    UserPosition = "Targoncavezet�",
                    TechnicianName = "Sz�kely J�zsef",
                    TechnicianPosition = "Targoncaszerel�",
                    ForkliftAdministrator = "Ferenczy S�ndor",
                    ForkliftAdminPosition = "Emel�g�p-�gyint�z�",
                    ForkliftAdminContact = "+36201234567"
                },
                UserManual = new Forklift.UserManualInformation
                {
                    DateOfTransfer = new DateOnly(2022, 10, 14),
                    IsOnlineManual = true,
                    ManualWebsite = "https://www.niketrans.hu/site/assets/files/1081/chbc2037-d.pdf",
                    SupplierType = Forklift.UserManualInformation.Supplier.DISTRIBUTOR,
                    SupplierSigneeName = "P�lffy J�nos",
                    SupplierSigneePosition = "Ad�sv�teli technikus",
                    RecipientType = Forklift.UserManualInformation.Recipient.CUSTOMER,
                    RecipientSigneeName = "Ferenczy S�ndor",
                    RecipientSigneePosition = "Emel�g�p-�gyint�z�"
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