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
            if (_context.Forklifts.Count() == 0)
            {
                _context.Forklifts.RemoveRange(_context.Forklifts);

                Forklift test = new Forklift
                {
                    UniqueId = new Guid(),
                    General = new Forklift.GeneralInformation
                    {
                        Name = "TestForklift1",
                        Manufacturer = "CAT",
                        Type = "DP20-35N3",
                        ControlMethod = Forklift.ControlMethod.SEAT,
                        ManufacturingYear = 2022,
                        ProductionNumber = "CTZXAB1222001",
                        ForkliftType = Forklift.ForkliftType.LIFT,
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
                    }
                };

                _context.Forklifts.Add(test);
                _context.OperatorInformation.Add(test.Operator);
                _context.SaveChanges();
            }

            Forklift[] forklifts = _context.Forklifts.ToArray();
            return View(forklifts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}