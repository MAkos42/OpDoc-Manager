using Microsoft.EntityFrameworkCore;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [Owned]
        public class AdapterInformation
        {
            public Guid Id { get; set; }

            public string ForkliftAdapter { get; set; }

            public List<Adapter> AdapterList { get; set; }

            //public List<ServiceDocument> AdapterDocumentation { get; set; }

        }
    }
}
