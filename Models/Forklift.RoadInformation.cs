﻿using Microsoft.EntityFrameworkCore;
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
            [Column("HeightTransportPosition")]
            public int HeightTransportPosition { get; set; }
            [Required]
            [Column("HeightMastLowered")]
            public int HeightMastLowered { get; set; }
            [Required]
            [Column("HeightMastRaised")]
            public int HeightMastRaised { get; set; }
            [Required]
            [Column("OuterTurningCircle")]
            public int OuterTurningCircle { get; set; }
            [Required]
            [Column("InnerTurningCircle")]
            public int InnerTurningCircle { get; set; }
            [Required]
            [Column("Wheelbase")]
            public int Wheelbase { get; set; }
            [Required]
            [Column("TrackWidthFront")]
            public int TrackWidthFront { get; set; }
            [Required]
            [Column("TrackWidthBack")]
            public int TrackWidthBack { get; set; }
            [Required]
            [Column("RideHeight")]
            public int RideHeight { get; set; }
            [Required]
            [Column("TopSpeedWithLoad")]
            public double TopSpeedWithLoad { get; set; }
            [Required]
            [Column("TopSpeedWithoutLoad")]
            public double TopSpeedWithoutLoad { get; set; }
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
            public string FrontWheelSize { get; set; }
            [Required]
            [Column("BackWheelSize")]
            public string BackWheelSize { get; set; }
            [Required]
            [Column("FrontWheelPressure")]
            public double FrontWheelPressure { get; set; }
            [Required]
            [Column("BackWheelPressure")]
            public double BackWheelPressure { get; set; }
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
