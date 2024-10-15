using Microsoft.EntityFrameworkCore;

namespace OpDoc_Manager.Data.Service
{
    public class ForkliftTypeService
    {
        private readonly ApplicationDbContext _context;

        public ForkliftTypeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ForkliftTypeDTO>> GetTypesAsync()
        {
            return await _context.ForkliftModels.Select(t => new ForkliftTypeDTO
            {
                Id = t.Id,
                Manufacturer = t.Manufacturer,
                Type = t.Model
            }).ToListAsync();
        }
    }
}
