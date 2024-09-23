namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class ForkliftAdapter
            {
            public int Id { get; set; }
            public string AdapterName { get; set; }
            public string AdapterType { get; set; }
            public string ProductionNumber { get; set; }
            public int Weight { get; set; }
            public int CenterOfMassOffset { get; set; }
            }
    }
}
