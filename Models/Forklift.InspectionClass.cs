namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public abstract class InspectionClass
        {
            public abstract PeriodicInspectionType InspectionType { get; }
        }

        public class ManufacturerInspectionClass : InspectionClass
        {
            public override PeriodicInspectionType InspectionType { get { return PeriodicInspectionType.MANUFACTURER; } }

            public string ManufacturerInstructionId { get; set; }
            public string? DistributorInstructionId { get; set; }
        }

        public class MSZ9721InspectionClass : InspectionClass
        {
            public override PeriodicInspectionType InspectionType { get { return PeriodicInspectionType.MSZ9721; } }
            public string MaintenanceGroup { get; set; }
            public string SigningLocation { get; set; }
            public DateOnly SignDate { get; set; }
            public string Signee { get; set; }
            public string SigneePosition { get; set; }
        }

        public class CustomMSZ9721InspectionClass : InspectionClass
        {
            public override PeriodicInspectionType InspectionType { get { return PeriodicInspectionType.MSZ9721CUSTOM; } }
            public string DefaultMaintenanceGroup { get; set; }
        }

    }
}
