﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public class PeriodicInspectionInformation
        {
            static readonly Dictionary<int, InspectionPeriods> MSZ9750CATEGORIES = new()
            {
                {1, new(){
                    StructuralInspectionOpHours = 1600,
                    StructuralInspectionMonths = 8,
                    MainInspectionPeriodOpHours = 4800,
                    MainInspectionPeriodMonths = 24
                    }
                },
                {2, new() {
                    StructuralInspectionOpHours = 1400,
                    StructuralInspectionMonths = 7,
                    MainInspectionPeriodOpHours = 4200,
                    MainInspectionPeriodMonths = 21
                    }
                },
                {3, new() {
                    StructuralInspectionOpHours = 1200,
                    StructuralInspectionMonths = 6,
                    MainInspectionPeriodOpHours = 3600,
                    MainInspectionPeriodMonths = 18
                    }
                },
                {4, new() {
                    StructuralInspectionOpHours = 800,
                    StructuralInspectionMonths = 4,
                    MainInspectionPeriodOpHours = 2400,
                    MainInspectionPeriodMonths = 12
                    }
                },
                {5, new() {
                    StructuralInspectionOpHours = 600,
                    StructuralInspectionMonths = 3,
                    MainInspectionPeriodOpHours = 1800,
                    MainInspectionPeriodMonths = 9
                    }
                }
            };


            [ForeignKey("Forklift")]
            public Guid Id { get; set; }

            [Required]
            public int OperatingHours { get; set; }
            [Required]
            public DateOnly LastInspectionDate { get; set; }

            [Required]
            [Column(TypeName = "text")]
            public InspectionCategory InspectionCategory { get; set; }
            public string? ManufacturerInspectionId { get; set; }
            public string? OperatorInspectionId { get; set; }

            public int? MSZ9750InspectionGroupId { get; set; }
            public DateOnly MSZ9750SignDate { get; set; }
            public string? MSZ9750SigneeName { get; set; }
            public string? MSZ9750SigneePosition { get; set; }

            [Required]
            public int StructuralInspectionOpHours { get; set; }
            [Required]
            public int StructuralInspectionMonths { get; set; }

            [Required]
            public int MainInspectionPeriodOpHours { get; set; }
            [Required]
            public int MainInspectionPeriodMonths { get; set; }

            public List<CustomInspectionPeriod>? CustomInspectionPeriodRecord { get; set; }

            public List<PeriodicInspectionResult>? InspectionResults { get; set; }

        }
    }

}
