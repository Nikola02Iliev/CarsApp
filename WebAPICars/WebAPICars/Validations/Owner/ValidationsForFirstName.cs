using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Owner
{
    public class ValidationsForFirstName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if(value is string firstName)
            {
                if (string.IsNullOrWhiteSpace(firstName)) 
                {
                    return new ValidationResult("This field is required!");
                }

                if (firstName.Length > 50) 
                {
                    return new ValidationResult("This field can't be more than 50 characters!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
