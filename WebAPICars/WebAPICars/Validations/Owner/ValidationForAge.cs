using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Owner
{
    public class ValidationForAge : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int age)
            {
                if (age < 0)
                {
                    return new ValidationResult("Year cannot be negative");
                }

            }

            return ValidationResult.Success;
        }
    }
}
