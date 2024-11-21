using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class AdapterRecord
        {
            public Guid Id { get; set; }

            [ForeignKey("AdapterInformation")]
            public Guid ForkliftId { get; set; }

            [Required]
            public int Number { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Type { get; set; }
            [Required]
            public string SerialNumber { get; set; }
            [Required]
            public int Weight { get; set; }
            [Required]
            public int LoadCenterDistance { get; set; }
        }
    }
}
