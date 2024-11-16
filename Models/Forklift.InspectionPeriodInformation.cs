using System.ComponentModel.DataAnnotations;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public struct InspectionPeriods
        {
            [Required]
            public int StructuralInspectionOpHours { get; set; }
            [Required]
            public int StructuralInspectionMonths { get; set; }

            [Required]
            public int MainInspectionPeriodOpHours { get; set; }
            [Required]
            public int MainInspectionPeriodMonths { get; set; }
        }
    }

}
