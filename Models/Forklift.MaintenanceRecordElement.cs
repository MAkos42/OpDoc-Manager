namespace OpDoc_Manager.Model.Entity
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
