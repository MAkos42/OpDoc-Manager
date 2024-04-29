namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public class ManagerInformation
        {
            public int RecordNumber { get; set; }
            public string Organisation { get; set; }
            public string Address { get; set; }
            public string ContactInfo { get; set; }
            public string ContactName { get; set; }
            public DateOnly StartDate { get; set; }
            public DateOnly? EndDate { get; set;}
        }
    }
}
