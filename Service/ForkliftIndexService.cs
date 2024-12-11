using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Data;
using OpDoc_Manager.Models.DTO;

namespace OpDoc_Manager.Service
{
    public class ForkliftIndexService : IForkliftIndexService
    {
        private readonly ApplicationDbContext _context;

        public ForkliftIndexService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForkliftIndexDTO>> GetIndexPageInformation()
        {
            return await _context.Forklifts.Select(f => new ForkliftIndexDTO
            {
                UniqueId = f.UniqueId,
                Name = f.General.Name,
                ProductionNumber = f.General.ProductionNumber,
                Manufacturer = f.General.Model.Manufacturer,
                Type = f.General.Model.Type,
                PowerSource = f.General.Model.PowerSource,
                Operator = f.Operator.Operator,
                OperatingHours = f.PeriodicInspection.OperatingHours,
                NextInspectionOpHours = f.PeriodicInspection.NextInspectionOpHours,
                NextInspectionDate = f.PeriodicInspection.NextInspectionDate
            }).OrderBy(x => x.Operator).ThenBy(x => x.Name).ToListAsync();
        }
    }
}
