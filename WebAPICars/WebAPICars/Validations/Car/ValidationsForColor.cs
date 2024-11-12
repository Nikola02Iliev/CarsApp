using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Car
{
    public class ValidationsForColor : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string color)
            {
                if (string.IsNullOrWhiteSpace(color))
                {
                    return new ValidationResult("This field is required!");
                }

                if (color.Length > 15)
                {
                    return new ValidationResult("Color can't be more than 15 characters!");
                }

            }

            return ValidationResult.Success;
        }
    }
}