namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public class OperationRecordElement
        {
            public int RecordNumber { get; set; }
            public string SiteLocation {  get; set; }
            public string OperationalArea { get; set; }
            public string Organisation { get; set; }
            public string OrganisationLeader {  get; set; }
            public DateOnly StartOfOperation { get; set; }
            public DateOnly? EndOfOperation { get;set; }
            public string Notes { get; set; }
        }
    }
}
