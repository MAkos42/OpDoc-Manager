using Microsoft.EntityFrameworkCore;
using OpDoc_Manager.Models;

namespace OpDoc_Manager.Data.Service
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
                Name = t.Manufacturer + " " + t.Type
            }).OrderBy(m => m.Name).ToListAsync();
        }

        public async Task<Forklift.ModelInformation?> GetModelByIndexAsync(string manufacturer, string type)
        {
            return await _context.ForkliftModels.FirstOrDefaultAsync(m => m.Manufacturer == manufacturer && m.Type == type);
        }
    }
}
