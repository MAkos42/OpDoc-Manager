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
            [Column("Model")]
            public string Model { get; set; }
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
            [Column("ForkliftType", TypeName = "text")]
            public ForkliftType ForkliftType { get; set; }
            [Required]
            [Column("OperatorType", TypeName = "text")]
            public OperatorType OperatorType { get; set; }
            [Required]
            [Column("PowerSource", TypeName = "text")]
            public PowerSource PowerSource { get; set; }
        }
    }
}