﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Index("Manufacturer", "Type", IsUnique = true)]
        public class ModelInformation
        {
            [Key]
            public Guid Id { get; set; }

            [Required]
            [MaxLength(50)]
            public string Manufacturer { get; set; }

            [Required]
            [MaxLength(50)]
            public string Type { get; set; }

            [Required]
            [Column("OperationMode", TypeName = "text")]
            public OperationMode OperationMode { get; set; }

            [Required]
            [Column("OperatorType", TypeName = "text")]
            public OperatorType OperatorType { get; set; }

            [Required]
            [Column("PowerSource", TypeName = "text")]
            public PowerSource PowerSource { get; set; }

            public LiftMechanism LiftMechanism { get; set; }

            public RoadInformation RoadInformation { get; set; }

            [ForeignKey("Engine")]
            public Guid EngineId { get; set; }

            public Engine Engine { get; set; }

            [Required]
            public bool IsActive { get; set; } = true;
        }
    }
}
