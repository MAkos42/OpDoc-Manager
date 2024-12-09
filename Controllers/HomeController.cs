using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OpDoc_Manager.Data;
using OpDoc_Manager.Models;
using System.Diagnostics;

namespace OpDoc_Manager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<OpDocUser> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<OpDocUser> UserManager)
        {
            _logger = logger;
            _context = context;
            _userManager = UserManager;
        }

        public async Task<IActionResult> Index()
        {

            //GenerateTestData();

            return RedirectToAction("Index", "Forklift");
        }

        private void GenerateTestData()
        {
            GenerateTestUsers();



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
                    BatteryWeight = null,
                    BreakingForce = 30000,
                    ParkingBreakForce = 40000
                },

                Engine = new Forklift.InternalCombustionEngine
                {
                    EngineType = Forklift.EngineType.ICE,
                    Manufacturer = "CAT",
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
                PowerSource = Forklift.PowerSource.ELECTRIC,

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

                    BatteryType = "n/a",
                    BatteryManufacturer = "n/a",
                    NominalBatteryCapacity = 775,
                    BatteryVoltage = 80,
                    BatteryCellCount = 12,

                    MotorManufacturer = "n/a",
                    MotorOutput = 8.0,
                    MotorRPM = 2000,

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
                    OwnerAddress = "3501 Miskolc, Tesztpálya út. 31.",
                    Operator = "Targonca Operations Kft.",
                    OperatorAddress = "3501 Miskolc, Tesztpálya út. 31.",
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
                    DateOfTransfer = new DateOnly(2022, 10, 10),
                    IsOnlineManual = true,
                    ManualWebsite = "https://www.niketrans.hu/site/assets/files/1081/chbc2037-d.pdf",
                    SupplierType = Forklift.UserManualInformation.Supplier.DISTRIBUTOR,
                    SupplierSigneeName = "Pálffy János",
                    SupplierSigneePosition = "Adásvételi technikus",
                    RecipientType = Forklift.UserManualInformation.Recipient.CUSTOMER,
                    RecipientSigneeName = "Ferenczy Sándor",
                    RecipientSigneePosition = "Emelõgép-ügyintézõ"
                },
                Adapter = new Forklift.AdapterInformation
                {
                    Name = "3A",
                    AdapterList = new List<Forklift.AdapterRecord>
                    {
                        new Forklift.AdapterRecord
                        {
                            Number = 1,
                            Name = "3300mm Simplex Carriage",
                            Type = "Simplex",
                            SerialNumber = "CTZXAB1222001S330001",
                            Weight = 85,
                            LoadCenterDistance = 500
                        },
                        new Forklift.AdapterRecord
                        {
                            Number = 2,
                            Name = "3000mm Simplex Carriage",
                            Type = "Simplex",
                            SerialNumber = "CTZXAB1222001S300001",
                            Weight = 85,
                            LoadCenterDistance = 500
                        }
                    }
                },
                PeriodicInspection = new Forklift.PeriodicInspectionInformation
                {
                    OperatingHours = 4755,
                    LastInspectionDate = new DateOnly(2024, 10, 11),
                    InspectionCategory = Forklift.InspectionCategory.MSZ9721,
                    MSZ9750InspectionGroupId = 1,
                    StructuralInspectionOpHours = 1600,
                    StructuralInspectionMonths = 8,
                    MainInspectionPeriodOpHours = 4800,
                    MainInspectionPeriodMonths = 24,
                    NextInspectionOpHours = 5400,
                    NextInspectionDate = new DateOnly(2025, 6, 11),
                    InspectionResults = new List<Forklift.PeriodicInspectionResult>
                    {
                        new Forklift.PeriodicInspectionResult
                        {
                            Type = Forklift.InspectionType.STRUCTURAL,
                            RequiredOperationHours = 1600,
                            CurrentOperatingHours= 1531,
                            RequiredInspectionDate = new DateOnly(2023, 6, 11),
                            InspectionDate = new DateOnly(2023, 6, 5),
                            InspectionReportId = "CTZXAB1222001-2023-06-05-001",
                            HasPassedInspection = true,
                            Technician = "Székely József"
                        },

                        new Forklift.PeriodicInspectionResult
                        {
                            Type = Forklift.InspectionType.STRUCTURAL,
                            RequiredOperationHours = 3200,
                            CurrentOperatingHours= 3022,
                            RequiredInspectionDate = new DateOnly(2024, 2, 5),
                            InspectionDate = new DateOnly(2024, 1, 26),
                            InspectionReportId = "CTZXAB1222001-2024-01-26-001",
                            HasPassedInspection = true,
                            Technician = "Székely József"
                        },

                        new Forklift.PeriodicInspectionResult
                        {
                            Type = Forklift.InspectionType.MAIN,
                            RequiredOperationHours = 4800,
                            CurrentOperatingHours= 4751,
                            RequiredInspectionDate = new DateOnly(2024, 10, 11),
                            InspectionDate = new DateOnly(2024, 10, 2),
                            InspectionReportId = "CTZXAB1222001-2024-10-02-001",
                            HasPassedInspection = true,
                            Technician = "Székely József"
                        }
                    },
                    MaintenanceReports = new List<Forklift.MaintenanceReport>
                    {
                        new Forklift.MaintenanceReport
                        {
                            Date = new DateOnly(2024, 6, 5),
                            OperatingHours = 3520,
                            Description = "Bal elsõ kerékgumi sérülés okozta cseréje."
                        }
                    }
                }
            };

            _context.Forklifts.Add(test);
            _context.OperatorInformation.Add(test.Operator);
            if (test.Operator.LeaseInformation != null)
                _context.LeaseInformation.Add(test.Operator.LeaseInformation);
            _context.UserManualInformation.Add(test.UserManual);
            _context.AdapterInformation.Add(test.Adapter);
            _context.Adapters.AddRange(test.Adapter.AdapterList);
            _context.PeriodicInspectionInformation.Add(test.PeriodicInspection);
            _context.periodicInspections.AddRange(test.PeriodicInspection.InspectionResults);
            _context.SaveChanges();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private void GenerateTestUsers()
        {
            var testUsers = new List<OpDocUser>
            {
                new OpDocUser
                {
                    UserName = "fsandor@opdoc.com",
                    Email = "fsandor@opdoc.com",
                    FirstName = "Ferenczy",
                    LastName = "Sándor",
                    EmailConfirmed = true
                },
                new OpDocUser
                {
                    UserName = "szjozsef@opdoc.com",
                    Email = "szjozsef@opdoc.com",
                    FirstName = "Székely",
                    LastName = "József",
                    EmailConfirmed = true
                },
                new OpDocUser
                {
                    UserName = "tbela@opdoc.com",
                    Email = "tbela@opdoc.com",
                    FirstName = "Tóth",
                    LastName = "Béla",
                    EmailConfirmed = true
                }
            };

            string[] roles = { "Admin", "Technician", "Operator" };

            foreach (var user in testUsers)
            {
                if (_userManager.FindByEmailAsync(user.Email).Result == null)
                {
                    var result = _userManager.CreateAsync(user, "Test123!").Result;
                    if (result.Succeeded)
                    {
                        _userManager.AddToRoleAsync(user, roles[testUsers.IndexOf(user)]).Wait();
                    }
                }
            }
        }
    }
}