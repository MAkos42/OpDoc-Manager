namespace OpDoc_Manager.Model.Entity
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
