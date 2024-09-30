using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class TechnicalInformation
        {
            [ForeignKey("Forklift")]
            public Guid Id { get; set; }

            public LiftMechanism Lift { get; set; }

            public RoadInformation RoadInformation { get; set; }

            //public EngineType EngineType { get; set; }

            //public Engine Engine { get; set; }
        }
    }
}
