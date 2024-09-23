namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class PeriodicInspectionElement
        {
            public int Id { get; set; }
            public string Type { get; set; }
            public int RequiredOperationHours { get; set; }
            public int RealOperatingHours { get; set; }
            public DateOnly RequiredInspectionDate { get; set; }
            public DateOnly RealInspectionDate { get; set; }
            public string InspectionReportId { get; set; }
            public bool HasPassedInspection { get; set; }
        }
    }
}
