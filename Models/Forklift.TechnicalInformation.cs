using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class TechnicalInformation
        {
            [ForeignKey("Forklift")]
            public Guid Id { get; set; }

            [ForeignKey("ModelInformation")]
            public Guid ModelId { get; set; }

            public ModelInformation Model { get; set; }

            [Required]
            public string EngineProductionNumber { get; set; }
        }







    }
}
