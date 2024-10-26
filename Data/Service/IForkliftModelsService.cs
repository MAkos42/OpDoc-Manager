using OpDoc_Manager.Models;

namespace OpDoc_Manager.Data.Service
{
    public interface IForkliftModelsService
    {
        Task<Forklift.ModelInformation?> GetModelByIndexAsync(string manufacturer, string type);
        Task<List<ForkliftModelSelectorDTO>> GetModelNamesAsync();
    }
}