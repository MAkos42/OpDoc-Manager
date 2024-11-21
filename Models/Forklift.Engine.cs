using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public abstract class Engine
        {
            public Guid Id { get; set; }

            [Required]
            [Column(TypeName = "text")]
            public EngineType EngineType { get; set; }
        }

        public class ElectricEngine : Engine
        {
            [Required]
            public string BatteryType { get; set; }
            [Required]
            public string BatteryManufacturer { get; set; }
            [Required]
            public int NominalBatteryCapacity { get; set; }
            [Required]
            public int BatteryVoltage { get; set; }
            [Required]
            public int BatteryCellCount { get; set; }

            [Required]
            public string MotorManufacturer { get; set; }
            [Required]
            public double MotorOutput { get; set; }
            [Required]
            public int MotorRPM { get; set; }

            [Required]
            public string InverterManufacturer { get; set; }
            [Required]
            public string InverterType { get; set; }
            [Required]
            public string InverterPerformance { get; set; }

            [Required]
            public string FrequencyConverterManufacturer { get; set; }
            [Required]
            public string FrequencyConverterType { get; set; }
            [Required]
            public string FrequencyConverterPerformance { get; set; }

        }

        public class InternalCombustionEngine : Engine
        {
            [Required]
            public string Manufacturer { get; set; }
            [Required]
            public string Type { get; set; }

            [Required]
            public double RatedOutput { get; set; }
            [Required]
            public int CylinderVolume { get; set; }
            public string? EnviromentalClassification { get; set; }

            public string? CatalyticConverter { get; set; }
            [Required]
            public int FuelCapacity { get; set; }
            public string? NatGasSafetyValveType { get; set; }

        }
    }
}
