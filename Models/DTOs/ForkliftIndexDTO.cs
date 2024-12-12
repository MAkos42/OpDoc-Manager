namespace OpDoc_Manager.Models.DTO
{
    public class ForkliftIndexDTO
    {
        public Guid UniqueId { get; set; }
        public string Name { get; set; }
        public string ProductionNumber { get; set; }
        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public Forklift.PowerSource PowerSource { get; set; }
        public string Operator { get; set; }
        public int OperatingHours { get; set; }
        public int NextInspectionOpHours { get; set; }
        public DateOnly NextInspectionDate { get; set; }
    }
}
