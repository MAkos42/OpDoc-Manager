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
            public string Owner { get; set; }
            [Required]
            public string OwnerAddress { get; set; }

            [Required]
            public bool IsDifferentOperator { get; set; } = false;
            public string? Operator { get; set; }
            public string? OperatorAddress { get; set; }
            public DateOnly? TransferDate { get; set; }
            public string? TransferID { get; set; }

            [Required]
            public string OperationArea { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public string UserPosition { get; set; }
            [Required]
            public string TechnicianName { get; set; }
            [Required]
            public string TechnicianPosition { get; set; }

            public LeaseInformation? LeaseInformation { get; set; }

            public string? ForkliftAdministrator { get; set; }
            public string? ForkliftAdminPosition { get; set; }
            [RegularExpression(@"^\+|(00)36[\d]{8,9}", ErrorMessage = "A telefonszám formátuma nem megfelelő (+36XX1234567)")]
            public string? ForkliftAdminContact { get; set; }
        }
    }
}
