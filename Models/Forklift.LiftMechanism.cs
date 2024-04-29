namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public class LiftMechanism
        {
            public int LoadCapacity { get; set; }
            public int NominalLiftHeight { get; set; }
            public int MaximumLiftHeight { get; set; }
            public int MaximumHeightLoadCapacity { get; set; }
            public double LoadedTraversalSpeed { get; set; }
            public double UnloadedTraversalSpeed { get; set; }
            public double ForwardTiltAngle { get; set; }
            public double BackwardTiltAngle { get; set; }
            public int FreeLiftHeight { get; set; }
        }
    }
}
