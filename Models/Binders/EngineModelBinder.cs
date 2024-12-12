using Microsoft.AspNetCore.Mvc.ModelBinding;
using OpDoc_Manager.Models;

public class EngineModelBinder : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        var engineTypeValue = bindingContext.ValueProvider.GetValue("Engine.EngineType").FirstValue;
        if (string.IsNullOrEmpty(engineTypeValue))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        Forklift.EngineType engineType;
        if (!Enum.TryParse(engineTypeValue, out engineType))
        {
            bindingContext.Result = ModelBindingResult.Failed();
            return Task.CompletedTask;
        }

        Forklift.Engine engine;
        switch (engineType)
        {
            case Forklift.EngineType.ELECTRIC:
                engine = new Forklift.ElectricEngine
                {
                    BatteryType = bindingContext.ValueProvider.GetValue("Engine.BatteryType").FirstValue,
                    BatteryManufacturer = bindingContext.ValueProvider.GetValue("Engine.BatteryManufacturer").FirstValue,
                    NominalBatteryCapacity = int.Parse(bindingContext.ValueProvider.GetValue("Engine.NominalBatteryCapacity").FirstValue),
                    BatteryVoltage = int.Parse(bindingContext.ValueProvider.GetValue("Engine.BatteryVoltage").FirstValue),
                    MotorManufacturer = bindingContext.ValueProvider.GetValue("Engine.MotorManufacturer").FirstValue,
                    MotorOutput = double.Parse(bindingContext.ValueProvider.GetValue("Engine.MotorOutput").FirstValue),
                    MotorRPM = int.Parse(bindingContext.ValueProvider.GetValue("Engine.MotorRPM").FirstValue),
                    InverterType = bindingContext.ValueProvider.GetValue("Engine.InverterType").FirstValue,
                    InverterManufacturer = bindingContext.ValueProvider.GetValue("Engine.InverterManufacturer").FirstValue,
                    InverterPerformance = bindingContext.ValueProvider.GetValue("Engine.InverterPerformance").FirstValue,
                    FrequencyConverterType = bindingContext.ValueProvider.GetValue("Engine.FrequencyConverterType").FirstValue,
                    FrequencyConverterManufacturer = bindingContext.ValueProvider.GetValue("Engine.FrequencyConverterManufacturer").FirstValue,
                    FrequencyConverterPerformance = bindingContext.ValueProvider.GetValue("Engine.FrequencyConverterPerformance").FirstValue,
                    BatteryCellCount = int.Parse(bindingContext.ValueProvider.GetValue("Engine.BatteryCellCount").FirstValue)
                };
                break;
            case Forklift.EngineType.ICE:
                engine = new Forklift.InternalCombustionEngine
                {
                    Manufacturer = bindingContext.ValueProvider.GetValue("Engine.Manufacturer").FirstValue,
                    Type = bindingContext.ValueProvider.GetValue("Engine.Type").FirstValue,
                    RatedOutput = double.Parse(bindingContext.ValueProvider.GetValue("Engine.RatedOutput").FirstValue),
                    CylinderVolume = int.Parse(bindingContext.ValueProvider.GetValue("Engine.CylinderVolume").FirstValue),
                    FuelCapacity = int.Parse(bindingContext.ValueProvider.GetValue("Engine.FuelCapacity").FirstValue),
                    EnviromentalClassification = bindingContext.ValueProvider.GetValue("Engine.EnviromentalClassification").FirstValue,
                    CatalyticConverter = bindingContext.ValueProvider.GetValue("Engine.CatalyticConverter").FirstValue,
                    NatGasSafetyValveType = bindingContext.ValueProvider.GetValue("Engine.NatGasSafetyValveType").FirstValue
                };
                break;
            default:
                bindingContext.Result = ModelBindingResult.Failed();
                return Task.CompletedTask;
        }

        bindingContext.Model = engine;
        bindingContext.Result = ModelBindingResult.Success(engine);
        return Task.CompletedTask;
    }
}
