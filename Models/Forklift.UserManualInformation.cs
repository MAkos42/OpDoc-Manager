namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class UserManualInformation
        {
            public enum ManualSupplier
            {
                MANUFACTURER,
                DISTRIBUTOR,
                LEASER
            }
            public enum ManualRecipient
            {
                OPERATOR,
                OWNER,
                LEASEE
            }

            public DateOnly DateOfTransfer { get; set; }
            public ManualSupplier Bestower { get; set; }
            public string BestowerName { get; set; }
            public string BestowerPosition { get; set; }
            public ManualRecipient Recipient {  get; set; }
            public string RecipientName { get; set; }
            public string RecipientPosition { get; set; }

            public bool IsOnlineManual { get; set; }
            public string? ManualAddress {  get; set; }

            public DateOnly? LeaseTransferDate { get; set; }
            public string? LeaserName { get; set; }
            public string? LeaserPosition { get; set; }
            public string? LeaseeName { get; set; }
            public string? LeaseePosition { get;set; }
        }
    }
}
