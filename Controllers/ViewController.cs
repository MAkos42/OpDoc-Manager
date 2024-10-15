using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Data;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public class ViewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ViewController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: View/guid
        public async Task<IActionResult> Index(Guid id)
        {
            var forklift = await _context.Forklifts
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (forklift == null)
            {
                return NotFound();
            }

            return View(forklift);
        }

        // GET: View/guid/Edit
        public async Task<IActionResult> Edit(Guid id)
        {
            var forklift = await _context.Forklifts
                .FirstOrDefaultAsync(m => m.UniqueId == id);
            if (forklift == null)
            {
                return NotFound("forklift");
            }
            var operatorInfo = await _context.OperatorInformation.FirstOrDefaultAsync(m => m.Id == id);
            if (operatorInfo == null)
            {
                return NotFound("operator information");
            }
            var tempLeaseInformation = new Forklift.ForkliftLeaseInformation();
            if (operatorInfo.LeaseInformation == null)
            {
                forklift.Operator.LeaseInformation = tempLeaseInformation;
            }
            var userManualInfo = await _context.UserManualInformation.FirstOrDefaultAsync(m => m.Id == id);
            if (userManualInfo == null)
            {
                return NotFound("user manual");
            }


            return View(forklift);
        }




        private bool ForkliftExists(string id)
        {
            return _context.Forklifts.Any(e => e.UniqueId == Guid.Parse(id));
        }
    }
}
