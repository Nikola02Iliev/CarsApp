using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Car
{
    public class ValidationsForImage : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) 
            {
                return new ValidationResult("This field is required!");
            }

            return ValidationResult.Success;
        }
    }
}
