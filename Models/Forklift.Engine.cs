using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        [ModelBinder(BinderType = typeof(EngineModelBinder))]
        public abstract class Engine
        {
            public Guid Id { get; set; }

            [Required]
            [Column(TypeName = "text")]
            public EngineType EngineType { get; set; }
        }

        public class ElectricEngine : Engine
        {
            public ElectricEngine()
            {
                EngineType = EngineType.ELECTRIC;
            }

            [Required]
            [MaxLength(50)]
            public string BatteryType { get; set; }
            [Required]
            [MaxLength(50)]
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
            [MaxLength(50)]
            public string InverterManufacturer { get; set; }
            [Required]
            [MaxLength(50)]
            public string InverterType { get; set; }
            [Required]
            [MaxLength(50)]
            public string InverterPerformance { get; set; }

            [Required]
            [MaxLength(50)]
            public string FrequencyConverterManufacturer { get; set; }
            [Required]
            [MaxLength(50)]
            public string FrequencyConverterType { get; set; }
            [Required]
            [MaxLength(50)]
            public string FrequencyConverterPerformance { get; set; }

        }

        public class InternalCombustionEngine : Engine
        {
            public InternalCombustionEngine()
            {
                EngineType = EngineType.ICE;
            }

            [Required]
            [MaxLength(50)]
            public string Manufacturer { get; set; }
            [Required]
            [MaxLength(50)]
            public string Type { get; set; }

            [Required]
            public double RatedOutput { get; set; }
            [Required]
            public int CylinderVolume { get; set; }
            [MaxLength(50)]
            public string? EnviromentalClassification { get; set; }

            [MaxLength(50)]
            public string? CatalyticConverter { get; set; }
            [Required]
            public int FuelCapacity { get; set; }
            [MaxLength(50)]
            public string? NatGasSafetyValveType { get; set; }

        }
    }
}
