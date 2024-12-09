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
            [MaxLength(100)]
            public string LeaserCompany { get; set; }
            [Required]
            [MaxLength(100)]
            public string LeaserName { get; set; }
            [Required]
            [MaxLength(100)]
            public string LeaserOrgUnit { get; set; }
            [Required]
            [MaxLength(100)]
            public string LeaserPosition { get; set; }
            [Required]
            [MaxLength(100)]
            public string LeaserContact { get; set; }

            [Required]
            [MaxLength(100)]
            public string LeaseeCompany { get; set; }
            [Required]
            [MaxLength(100)]
            public string LeaseeName { get; set; }
            [Required]
            [MaxLength(100)]
            public string LeaseeOrgUnit { get; set; }
            [Required]
            [MaxLength(100)]
            public string LeaseePosition { get; set; }
            [Required]
            [MaxLength(100)]
            public string LeaseeContact { get; set; }
        }
    }
}
