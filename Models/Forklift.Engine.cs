using System.ComponentModel.DataAnnotations.Schema;
using static OpDoc_Manager.Models.Forklift;

namespace OpDoc_Manager.Models
{
    public partial class Forklift
    {
        public abstract class Engine
        {
            [ForeignKey("Forklift")]
            public Guid Id { get; set; }

        }
    }

    public class ElectricEngine : Engine
    {

        public string BatteryType { get; set; }
        public string BatteryManufacturer { get; set; }
        public int NominalBatteryCapacity { get; set; }
        public int BatteryVoltage { get; set; }
        public int BatteryCellCount { get; set; }

        public string EngineManufacturer { get; set; }
        public int EngineOutput { get; set; }
        public int EngineRPM { get; set; }

        public string InverterManufacturer { get; set; }
        public string InverterType { get; set; }
        public int InverterPerformance { get; set; }

        public string FrequencyConverterManufacturer { get; set; }
        public string FrequencyConverterType { get; set; }
        public string FrequencyConverterPerformance { get; set; }

    }

    public class InternalCombustionEngine : Engine
    {

        public string Manufacturer { get; set; }
        public string Type { get; set; }
        public string ProductionNumber { get; set; }
        public int EngineOutput { get; set; }
        public int CylinderVolume { get; set; }
        public string? EnviromentalClassification { get; set; }
        public string? CatalyticConverter { get; set; }
        public int FuelCapacity { get; set; }
        public string? NatGasSafetyValveType { get; set; }

    }
}
