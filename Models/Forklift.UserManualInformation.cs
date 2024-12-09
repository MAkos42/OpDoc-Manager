using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class UserManualInformation
        {
            public enum Supplier
            {
                MANUFACTURER,
                DISTRIBUTOR,
                SELLER,
                LEASER
            }
            public enum Recipient
            {
                OPERATOR,
                CUSTOMER,
                LEASEE
            }

            [ForeignKey("Forklift")]
            public Guid Id { get; set; }

            [Required]
            public DateOnly DateOfTransfer { get; set; }
            [Required]
            [Column(TypeName = "text")]
            public Supplier SupplierType { get; set; }
            [Required]
            [MaxLength(100)]
            public string SupplierSigneeName { get; set; }
            [Required]
            [MaxLength(100)]
            public string SupplierSigneePosition { get; set; }
            [Required]
            [Column(TypeName = "text")]
            public Recipient RecipientType { get; set; }
            [Required]
            [MaxLength(100)]
            public string RecipientSigneeName { get; set; }
            [Required]
            [MaxLength(100)]
            public string RecipientSigneePosition { get; set; }

            [Required]
            public bool IsOnlineManual { get; set; }
            [MaxLength(250)]
            public string? ManualWebsite { get; set; }

            public DateOnly? LeaseReturnDate { get; set; }
            [MaxLength(100)]
            public string? LeaseeSigneeName { get; set; }
            [MaxLength(100)]
            public string? LeaseeSigneePosition { get; set; }
            [MaxLength(100)]
            public string? LeaserSigneeName { get; set; }
            [MaxLength(100)]
            public string? LeaserSigneePosition { get; set; }
        }
    }
}
