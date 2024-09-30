using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Owned]
        public class RoadInformation
        {
            [Required]
            [Column("Width")]
            public int Width { get; set; }
            [Required]
            [Column("Length")]
            public int Length { get; set; }
            [Required]
            [Column("TransportHeight")]
            public int TransportHeight { get; set; }
            [Required]
            [Column("MaximumTransportHeight")]
            public int MaximumTransportHeight { get; set; }
            [Required]
            [Column("MaximumOperationalHeight")]
            public int MaximumOperationalHeight { get; set; }
            [Required]
            [Column("OuterTurningCircle")]
            public int OuterTurningCircle { get; set; }
            [Required]
            [Column("InnerTurningCircle")]
            public int InnerTurningCircle { get; set; }
            [Required]
            [Column("AxleWidth")]
            public int AxleWidth { get; set; }
            [Required]
            [Column("FrontWheelspan")]
            public int FrontWheelspan { get; set; }
            [Required]
            [Column("BackWheelspan")]
            public int BackWheelspan { get; set; }
            [Required]
            [Column("RideHeight")]
            public int RideHeight { get; set; }
            [Required]
            [Column("LoadedTopSpeed")]
            public int LoadedTopSpeed { get; set; }
            [Required]
            [Column("UnloadedTopSpeed")]
            public int UnloadedTopSpeed { get; set; }
            [Required]
            [Column("TractiveForce")]
            public int TractiveForce { get; set; }
            [Required]
            [Column("FrontWheelCount")]
            public int FrontWheelCount { get; set; }
            [Required]
            [Column("BackWheelCount")]
            public int BackWheelCount { get; set; }
            [Required]
            [Column("FrontWheelSize")]
            public int FrontWheelSize { get; set; }
            [Required]
            [Column("BackWheelSize")]
            public int BackWheelSize { get; set; }
            [Required]
            [Column("FrontWheelPressure")]
            public int FrontWheelPressure { get; set; }
            [Required]
            [Column("BackWheelPressure")]
            public int BackWheelPressure { get; set; }
            [Required]
            [Column("OperationalWeight")]
            public int OperationalWeight { get; set; }
            [Required]
            [Column("BatteryWeight")]
            public int BatteryWeight { get; set; }
            [Required]
            [Column("BreakingForce")]
            public int BreakingForce { get; set; }
            [Required]
            [Column("ParkingBreakForce")]
            public int ParkingBreakForce { get; set; }
        }
    }
}
