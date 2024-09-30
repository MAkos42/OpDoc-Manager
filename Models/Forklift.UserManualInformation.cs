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
            public string SupplierSigneeName { get; set; }
            [Required]
            public string SupplierSigneePosition { get; set; }
            [Required]
            [Column(TypeName = "text")]
            public Recipient RecipientType { get; set; }
            [Required]
            public string RecipientSigneeName { get; set; }
            [Required]
            public string RecipientSigneePosition { get; set; }

            [Required]
            public bool IsOnlineManual { get; set; }
            public string? ManualWebsite { get; set; }

            public DateOnly? LeaseReturnDate { get; set; }
            public string? LeaseeSigneeName { get; set; }
            public string? LeaseeSigneePosition { get; set; }
            public string? LeaserSigneeName { get; set; }
            public string? LeaserSigneePosition { get; set; }
        }
    }
}
