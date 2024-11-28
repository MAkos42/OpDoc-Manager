using OpDoc_Manager.Models;
using OpDoc_Manager.Models.DTO;

namespace OpDoc_Manager.Service
{
    public interface IForkliftModelsService
    {
        Task<List<ForkliftModelDTO>> GetModelBaseInformationAsync();
        Task<Forklift.ModelInformation?> GetModelByIndexAsync(string manufacturer, string type);
        Task<List<ForkliftModelSelectorDTO>> GetModelNamesAsync();
    }
}