using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Index("Manufacturer", "Type", IsUnique = true)]
        public class ModelInformation
        {
            [Key]
            public Guid Id { get; set; }

            [Required]
            public string Manufacturer { get; set; }

            [Required]
            public string Type { get; set; }

            public LiftMechanism LiftMechanism { get; set; }

            public RoadInformation RoadInformation { get; set; }

            [ForeignKey("Engine")]
            public Guid EngineId { get; set; }

            public Engine Engine { get; set; }
        }
    }
}
