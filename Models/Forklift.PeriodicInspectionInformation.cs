namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class PeriodicInspectionInformation
        {
            InspectionClass InspectionClass { get; set; }
            public int StructuralInspectionPeriod { get; set; }
            public InspectionPeriodType StructuralInspectionPeriodType { get; set; }
            public int MainInspectionPeriod { get; set; }
            public InspectionPeriodType MainInspectionPeriodType { get; set; }
            public ICollection<CustomInspectionPeriod>? CustomInspectionPeriodRecord { get; set; }

            public ICollection<PeriodicInspectionElement> InspectionReports {  get; set; }

        }
    }

}
