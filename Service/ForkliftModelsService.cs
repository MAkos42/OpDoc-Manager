using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Data;
using OpDoc_Manager.Models;
using OpDoc_Manager.Models.DTO;

namespace OpDoc_Manager.Service
{
    public class ForkliftModelsService : IForkliftModelsService
    {
        private readonly ApplicationDbContext _context;

        public ForkliftModelsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForkliftModelSelectorDTO>> GetModelNamesAsync()
        {
            return await _context.ForkliftModels.Select(t => new ForkliftModelSelectorDTO
            {
                Id = t.Id,
                Manufacturer = t.Manufacturer,
                Type = t.Type
            }).OrderBy(m => m.Manufacturer).ThenBy(m => m.Type).ToListAsync();
        }

        public async Task<Forklift.ModelInformation?> GetModelByIndexAsync(string manufacturer, string type)
        {
            return await _context.ForkliftModels.FirstOrDefaultAsync(m => m.Manufacturer == manufacturer && m.Type == type);
        }

        public async Task<List<ForkliftModelIndexDTO>> GetModelIndexInformationAsync()
        {
            return await _context.ForkliftModels.Select(m => new ForkliftModelIndexDTO
            {
                Id = m.Id,
                Manufacturer = m.Manufacturer,
                Type = m.Type,
                OperationMode = m.OperationMode,
                OperatorType = m.OperatorType,
                PowerSource = m.PowerSource
            }).ToListAsync();
        }
    }
}
