using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class MaintenanceReport
        {
            [Key]
            public Guid Id { get; set; }

            [ForeignKey("PeriodicInspectionInformation")]
            public Guid ForkliftId { get; set; }

            [Required]
            public DateOnly Date { get; set; }
            [Required]
            public int OperatingHours { get; set; }
            [Required]
            public string RepairDetails { get; set; }
        }
    }
}
