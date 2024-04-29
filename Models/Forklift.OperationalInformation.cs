namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public class OperationalInformation
        {
            public string Owner { get; set; }
            public string OwnerAddress { get; set; }

            public string? OperatorCompany { get; set; }
            public string? OperatorCompanyAdress { get; set; }
            public DateOnly? TransferDate { get; set; }
            public string? TransferID { get; set; }

            public string OperationLocation { get; set; }
            public string Operator { get; set; }
            public string OperatorPosition { get; set; }
            public string Technician { get; set; }
            public string TechnicianPosition { get; set; }
            public ForkliftLeaseInformation? LeaseInformation { get; set; } = null!;

            public string? ForkliftAdministrator { get; set; }
            public string? ForkliftAdminPosition { get; set; }
            public string? ForkliftAdminContact { get; set; }
        }
    }
}
