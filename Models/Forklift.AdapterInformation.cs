using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class AdapterInformation
        {
            [ForeignKey("Forklift")]
            public Guid Id { get; set; }

            [Required]
            public string Name { get; set; }

            public List<AdapterRecord> AdapterList { get; set; }

        }
    }
}
