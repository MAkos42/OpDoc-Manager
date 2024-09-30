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
            public int LoadCapacity { get; set; }
            [Required]
            [Column("NominalLiftHeight")]
            public int NominalLiftHeight { get; set; }
            [Required]
            [Column("MaximumLiftHeight")]
            public int MaximumLiftHeight { get; set; }
            [Required]
            [Column("MaximumHeightLoadCapacity")]
            public int MaximumHeightLoadCapacity { get; set; }
            [Required]
            [Column("LoadedTraversalSpeed")]
            public double LoadedTraversalSpeed { get; set; }
            [Required]
            [Column("UnloadedTraversalSpeed")]
            public double UnloadedTraversalSpeed { get; set; }
            [Required]
            [Column("ForwardTiltAngle")]
            public double ForwardTiltAngle { get; set; }
            [Required]
            [Column("BackwardTiltAngle")]
            public double BackwardTiltAngle { get; set; }
            [Required]
            [Column("FreeLiftHeight")]
            public int FreeLiftHeight { get; set; }
        }
    }
}
