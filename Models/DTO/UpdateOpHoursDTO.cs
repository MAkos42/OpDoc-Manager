using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace OpDoc_Manager.Models.DTO
{
    public class UpdateOpHoursDTO
    {
        public Guid ForkliftId { get; set; }

        public int Old { get; set; }
        [Required]
        [GreaterThan("Old", ErrorMessage = "Az új üzemóra számnak magasabbnak kell lennie a réginél!")]
        public int New { get; set; }
    }

    public class GreaterThanAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string _comparisonProperty;

        public GreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            // Add custom attributes to enable client-side validation
            context.Attributes["data-val"] = "true";
            context.Attributes["data-val-greaterthan"] = ErrorMessage ?? $"Value must be greater than {_comparisonProperty}.";
            context.Attributes["data-val-greaterthan-comparisonproperty"] = _comparisonProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // Get the property to compare against
            var comparisonPropertyInfo = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (comparisonPropertyInfo == null)
            {
                return new ValidationResult($"Unknown property: {_comparisonProperty}");
            }

            // Get the value of the comparison property
            var comparisonValue = comparisonPropertyInfo.GetValue(validationContext.ObjectInstance);

            // Ensure both values are comparable numbers
            if (value is IComparable currentValue && comparisonValue is IComparable otherValue)
            {
                if (currentValue.CompareTo(otherValue) <= 0)
                {
                    return new ValidationResult(ErrorMessage ?? $"{validationContext.DisplayName} must be greater than {_comparisonProperty}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
