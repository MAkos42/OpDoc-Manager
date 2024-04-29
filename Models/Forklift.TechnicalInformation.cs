namespace OpDoc_Manager.Model.Entity
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
