namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class AdapterInformation
        {
            public string AdapterClassification { get; set; }
            ICollection<ForkliftAdapter> AdapterList { get; set; }

            public ServiceDocumentList AdapterServiceDocumentation { get; set; }

        }
    }
}
