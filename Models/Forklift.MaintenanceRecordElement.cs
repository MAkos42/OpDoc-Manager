namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class MaintenanceRecordElement
        {
            public int Id { get; set; }
            public DateOnly Date {  get; set; }
            public int OperatingHours { get; set; }
            public string RepairDetails { get; set; }
        }
    }
}
