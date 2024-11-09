using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Service
{
    public class ValidationForCost : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value == null)
            {
                return new ValidationResult("This field is required.");
            }

            if (value is decimal cost)
            {
                if (cost < 0)
                {
                    return new ValidationResult("Cost cannot be negative.");
                }
            }
            
            return ValidationResult.Success;
        }
    }
}
