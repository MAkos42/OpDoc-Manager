using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace OpDoc_Manager.Model.Entity
{
    public partial class Forklift
    {
        [Owned]
        public class GeneralInformation
        {
            [Required]
            public string Name { get; set; }
            [Required]
            public string Manufacturer { get; set; }
            [Required]
            public string Type { get; set; }
            [Required]
            public ControlMethod ControlMethod {  get; set; }
            [Required]
            public int ManufacturingYear { get; set; }
            [Required]
            public string ProductionNumber { get; set; }
            [Required]
            public ForkliftType ForkliftType { get; set; }
            [Required]
            public EnergySource EnergySource { get; set; }
            [Required]
            public DateOnly EntryIntoService { get; set; }
        }
    }
}