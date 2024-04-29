namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public class RoadInformation
        {
            public int Width { get; set; }
            public int Length { get; set; }
            public int TransportHeight { get; set; }
            public int MaximumTransportHeight { get; set; }
            public int MaximumOperationalHeight { get; set; }
            public int OuterTurningCircle { get; set; }
            public int InnerTurningCircle { get; set; }
            public int AxleWidth { get; set; }
            public int FrontWheelspan { get; set; }
            public int BackWheelspan { get; set;}
            public int RideHeight { get; set; }
            public int LoadedTopSpeed { get; set; }
            public int UnloadedTopSpeed { get; set; }
            public int TractiveForce { get; set; }
            public int FrontWheelCount { get; set; }
            public int BackWheelCount { get; set;}
            public int FrontWheelSize { get; set; }
            public int BackWheelSize { get; set;}
            public int FrontWheelPressure { get; set; }
            public int BackWheelPressure { get; set; }
            public int OperationalWeight { get; set; }
            public int? BatteryWeight { get; set; }
            public int BreakingForce { get; set; }
            public int ParkingBreakForce { get; set; }
        }
    }
}
