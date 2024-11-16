using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class PeriodicInspectionInformation
        {
            [ForeignKey("Forklift")]
            public Guid Id { get; set; }

            [Required]
            public int OperatingHours { get; set; }
            [Required]
            public DateOnly LastInspectionDate { get; set; }

            [Required]
            InspectionType InspectionType { get; set; }
            public string? ManufacturerInspectionId { get; set; }
            public string? OperatorInspectionId { get; set; }

            public string? MSZ9750InspectionGroupId { get; set; }
            public DateOnly MSZ9750SignDate { get; set; }
            public string? MSZ9750SigneeName { get; set; }
            public string? MSZ9750SigneePosition { get; set; }

            public string? ModifiedInspectionGroup { get; set; }

            public int StructuralInspectionOpHours { get; set; }
            public int StructuralInspectionMonths { get; set; }

            public int MainInspectionPeriodOpHours { get; set; }
            public int MainInspectionPeriodMonths { get; set; }

            public InspectionPeriodType? CheckInspectionType { get; set; }
            public InspectionPeriodType StructuralInspectionType { get; set; }
            public InspectionPeriodType MainInspectionType { get; set; }
            public List<CustomInspectionPeriod>? CustomInspectionPeriodRecord { get; set; }

            public List<PeriodicInspectionResult>? InspectionResults { get; set; }

        }
    }

}
