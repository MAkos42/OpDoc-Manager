using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class PeriodicInspectionResult
        {
            [Key]
            public Guid Id { get; set; }
            [ForeignKey("PeriodicInspectionInformation")]
            public Guid ForkliftId { get; set; }
            [Required]
            [Column(TypeName = "text")]
            public InspectionType Type { get; set; }
            [Required]
            public int RequiredOperationHours { get; set; }
            [Required]
            public int CurrentOperatingHours { get; set; }
            [Required]
            public DateOnly RequiredInspectionDate { get; set; }
            [Required]
            public DateOnly InspectionDate { get; set; }
            [Required]
            [MaxLength(100)]
            public string InspectionReportId { get; set; }
            [Required]
            public bool HasPassedInspection { get; set; }
            [Required]
            [MaxLength(100)]
            public string Technician { get; set; }
        }
    }
}
