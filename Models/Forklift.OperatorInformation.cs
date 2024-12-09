using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class OperatorInformation
        {
            [ForeignKey("Forklift")]
            public Guid Id { get; set; }
            [Required]
            [MaxLength(100)]
            public string Owner { get; set; }
            [Required]
            [MaxLength(100)]
            public string OwnerAddress { get; set; }

            [Required]
            public bool IsDifferentOperator { get; set; } = false;
            [Required]
            [MaxLength(100)]
            public string Operator { get; set; }
            [Required]
            [MaxLength(100)]
            public string OperatorAddress { get; set; }
            public DateOnly? TransferDate { get; set; }
            [MaxLength(100)]
            public string? TransferID { get; set; }

            [Required]
            [MaxLength(100)]
            public string OperationArea { get; set; }
            [Required]
            [MaxLength(100)]
            public string UserName { get; set; }
            [Required]
            [MaxLength(100)]
            public string UserPosition { get; set; }
            [Required]
            [MaxLength(100)]
            public string TechnicianName { get; set; }
            [Required]
            [MaxLength(100)]
            public string TechnicianPosition { get; set; }

            public LeaseInformation? LeaseInformation { get; set; }

            [MaxLength(100)]
            public string? ForkliftAdministrator { get; set; }
            [MaxLength(100)]
            public string? ForkliftAdminPosition { get; set; }

            [Required]
            [RegularExpression(@"^(\+|(00))36[\d]{8,9}$", ErrorMessage = "A telefonszám formátuma nem megfelelő (+36XX1234567)")]
            [MaxLength(100)]
            public string? ForkliftAdminContact { get; set; }
        }
    }
}
