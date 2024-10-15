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
            public string Name { get; set; }
            [Required]
            [Column("Manufacturer")]
            public string Manufacturer { get; set; }
            [Required]
            [Column("Type")]
            public string Type { get; set; }
            [Required]
            [Column("ManufacturingYear")]
            public int ManufacturingYear { get; set; }
            [Required]
            [Column("ProductionNumber")]
            public string ProductionNumber { get; set; }
            [Required]
            [Column("EntryIntoService")]
            public DateOnly EntryIntoService { get; set; }
            [Required]
            [Column("OperationType", TypeName = "text")]
            public OperationType OperationType { get; set; }
            [Required]
            [Column("ControlMethod", TypeName = "text")]
            public ControlMethod ControlMethod { get; set; }
            [Required]
            [Column("EnergySource", TypeName = "text")]
            public EnergySource EnergySource { get; set; }
        }
    }
}