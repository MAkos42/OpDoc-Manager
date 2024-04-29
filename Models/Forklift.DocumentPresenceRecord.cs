namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public class DocumentPresenceRecord
        {
            public bool IsPresent { get; set; }
            public DateOnly Date { get; set; }
            public bool? IsReplaced { get; set; }
            public DateOnly? RepalcementDate { get; set; }
        }

    }
}
