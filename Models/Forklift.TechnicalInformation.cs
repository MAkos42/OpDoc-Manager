using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Index("Manufacturer", "Type", IsUnique = true)]
        public class TechnicalInformation
        {
            [Key]
            public Guid Id { get; set; }

            public string Manufacturer { get; set; }

            public string Type { get; set; }

            public LiftMechanism Lift { get; set; }

            public RoadInformation RoadInformation { get; set; }

            public Engine Engine { get; set; }
        }
    }
}
