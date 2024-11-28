using OpDoc_Manager.Models.DTO;

namespace OpDoc_Manager.Models
{
    public class EditorViewModel
    {
        public Forklift Forklift { get; set; }
        public List<ForkliftModelSelectorDTO> ModelNames { get; set; }
    }
}
