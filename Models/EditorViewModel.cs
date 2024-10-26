using OpDoc_Manager.Data.Service;

namespace OpDoc_Manager.Models
{
    public class EditorViewModel
    {
        public Forklift Forklift { get; set; }
        public List<ForkliftModelSelectorDTO> ModelNames { get; set; }
    }
}
