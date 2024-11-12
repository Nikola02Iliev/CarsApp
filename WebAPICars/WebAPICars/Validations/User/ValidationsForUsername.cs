using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.User
{
    public class ValidationsForUsername : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string username) 
            {
                if (string.IsNullOrWhiteSpace(username)) 
                {
                    return new ValidationResult("This field is required!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
