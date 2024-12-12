using static OpDoc_Manager.Models.Forklift;

namespace OpDoc_Manager.Models.DTO
{
    public class ForkliftModelIndexDTO
    {
        public Guid Id { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public OperationMode OperationMode { get; set; }
        public OperatorType OperatorType { get; set; }
        public PowerSource PowerSource { get; set; }
    }
}
