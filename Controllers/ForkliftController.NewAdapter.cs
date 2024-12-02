using Microsoft.AspNetCore.Mvc;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Controllers
{
    public partial class ForkliftController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> NewAdapter(Guid id, int number)
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

            return await Task.FromResult(PartialView("EditPartials/_AdapterRecord", returnList));
        }
    }
}
