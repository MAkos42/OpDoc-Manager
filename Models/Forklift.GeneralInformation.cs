using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Owned]
        public class GeneralInformation
        {
            [Required]
            [Column("Name")]
            [MaxLength(100)]
            public string Name { get; set; }

            [ForeignKey("ModelInformation")]
            [Column("ModelId")]
            public Guid ModelId { get; set; }

            public ModelInformation Model { get; set; }

            [Required]
            [Column("ManufacturingYear")]
            public int ManufacturingYear { get; set; }
            [Required]
            [Column("ProductionNumber")]
            [MaxLength(50)]
            public string ProductionNumber { get; set; }
            [Required]
            [Column("EntryIntoService")]
            public DateOnly EntryIntoService { get; set; }
            [Required]
            [Column("EngineProductionNumber")]
            [MaxLength(50)]
            public string EngineProductionNumber { get; set; }

        }
    }
}