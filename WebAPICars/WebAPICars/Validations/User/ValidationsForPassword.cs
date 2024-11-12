using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.User
{
    public class ValidationsForPassword : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string password) 
            {
                if (string.IsNullOrWhiteSpace(password))
                {
                    return new ValidationResult("This field is required!");
                }
            }


            return ValidationResult.Success;
        }
    }
}
