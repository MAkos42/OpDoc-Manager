using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class LeaseInformation
        {
            [ForeignKey("OperatorInformation")]
            public Guid Id { get; set; }
            [Required]
            public string LeaserCompany { get; set; }
            [Required]
            public string LeaserName { get; set; }
            [Required]
            public string LeaserOrgUnit { get; set; }
            [Required]
            public string LeaserPosition { get; set; }
            [Required]
            public string LeaserContact { get; set; }

            [Required]
            public string LeaseeCompany { get; set; }
            [Required]
            public string LeaseeName { get; set; }
            [Required]
            public string LeaseeOrgUnit { get; set; }
            [Required]
            public string LeaseePosition { get; set; }
            [Required]
            public string LeaseeContact { get; set; }
        }
    }
}
