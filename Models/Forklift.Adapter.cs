using System.ComponentModel.DataAnnotations;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class Adapter
        {
            [Key]
            public Guid UniqueId { get; set; }
            [Required]
            public int Id { get; set; }
            [Required]
            public string Name { get; set; }
            [Required]
            public string Type { get; set; }
            [Required]
            public string ProductionNumber { get; set; }
            [Required]
            public int Weight { get; set; }
            [Required]
            public int CenterOfMassOffset { get; set; }
        }
    }
}
