using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Car
{
    public class ValidationForPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is decimal price)
            {
                if (price < 0)
                {
                    return new ValidationResult("Price cannot be negative number");
                }

            }

            return ValidationResult.Success;
        }
    }
}
