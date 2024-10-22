using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Owned]
        public class LiftMechanism
        {
            [Required]
            [Column("LoadCapacity")]
            public double LoadCapacity { get; set; }
            [Required]
            [Column("FreeLift")]
            public int FreeLift { get; set; }
            [Required]
            [Column("NominalLiftHeight")]
            public int NominalLiftHeight { get; set; }
            [Required]
            [Column("MaxLiftHeight")]
            public int MaxLiftHeight { get; set; }
            [Required]
            [Column("MaxHeightMaxLoad")]
            public double MaxHeightMaxLoad { get; set; }
            [Required]
            [Column("LiftSpeedUnloaded")]
            public double LiftSpeedUnloaded { get; set; }
            [Required]
            [Column("LiftSpeedLoaded")]
            public double LiftSpeedLoaded { get; set; }
            [Required]
            [Column("MastForwardTiltAngle")]
            public double MastForwardTiltAngle { get; set; }
            [Required]
            [Column("MastBackwardTiltAngle")]
            public double MastBackwardTiltAngle { get; set; }
        }
    }
}
