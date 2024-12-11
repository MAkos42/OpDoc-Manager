using OpDoc_Manager.Models.DTO;

namespace OpDoc_Manager.Service
{
    public interface IForkliftIndexService
    {
        Task<List<ForkliftIndexDTO>> GetIndexPageInformationAsync();
    }
}