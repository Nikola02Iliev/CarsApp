using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Owner
{
    public class ValidationsForAddress : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is string address) 
            {
                if (string.IsNullOrWhiteSpace(address)) 
                {
                    return new ValidationResult("This field is required!");
                }

                if (address.Length > 255) 
                {
                    return new ValidationResult("This field can't be more than 255 characters!");
                }

            }

            return ValidationResult.Success;
        }
    }
}
