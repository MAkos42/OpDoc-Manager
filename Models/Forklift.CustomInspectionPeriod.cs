namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        public class CustomInspectionPeriod
        {
            public int Id { get; set; }
            public string Designation { get; set; }
            public int ManufacturerOperatingHours { get; set; }
            public int? ControlInspectionOH { get; set; }
            public int? ControlInspectionMonths { get; set; }
            public int StructuralInspectionOH { get; set; }
            public int StructuralInspectionMonths { get; set; }
            public int MainInspectionOH { get; set; }
            public int MainInspectionMonths { get; set; }
        }
    }
}
