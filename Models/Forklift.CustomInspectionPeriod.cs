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
            public string Name { get; set; }
            [Required]
            public int ManufacturerOperatingHours { get; set; }
            public int? CheckInspectionPeriod { get; set; }
            [Required]
            public int StructuralInspectionPeriod { get; set; }
            [Required]
            public int MainInspectionPeriod { get; set; }
        }
    }
}
