using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class CustomInspectionPeriod
        {
            public Guid Id { get; set; }

            [ForeignKey("PeriodicInspectionInformation")]
            public Guid ForkliftId { get; set; }

            [Required]
            public int Number { get; set; }
            [Required]
            [MaxLength(100)]
            public string Name { get; set; }
            [Required]
            public int ManufacturerOperatingHours { get; set; }

            public int? ControlInspectionPeriod { get; set; }
            [Column(TypeName = "text")]
            public InspectionPeriodType? ControlInspectionType { get; set; }

            [Required]
            public int StructuralInspectionPeriod { get; set; }
            [Required]
            [Column(TypeName = "text")]
            public InspectionPeriodType StructuralInspectionType { get; set; }

            [Required]
            public int MainInspectionPeriod { get; set; }
            [Required]
            [Column(TypeName = "text")]
            public InspectionPeriodType MainInspectionType { get; set; }
        }
    }
}
