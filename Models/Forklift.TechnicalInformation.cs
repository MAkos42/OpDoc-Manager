namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class TechnicalInformation
        {
            public LiftMechanism Lift { get; set; }
            public RoadInformation RoadInformation { get; set; }
            public Engine Engine { get; set; }
        }
    }
}
