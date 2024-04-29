
namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public class ForkliftLeaseInformation
        {
            public string LeaserOrganisation { get; set; }
            public string LeaserName { get; set; }
            public string LeaserOrgUnit {  get; set; }
            public string LeaserPosition { get; set; }
            public string LeaserContact { get; set;}

            public string LeaseeOrganisation { get; set; }
            public string LeaseeName { get; set; }
            public string LeaseeOrgUnit { get; set; }
            public string LeaseePosition { get; set; }
            public string LeaseeContact { get; set; }
        }
    }
}
