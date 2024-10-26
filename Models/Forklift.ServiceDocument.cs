namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class ServiceDocument
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public bool IsPresent { get; set; }
            public DateOnly Date { get; set; }
            public bool? IsReplaced { get; set; }
            public DateOnly? RepalcementDate { get; set; }
        }

    }
}
