using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.User
{
    public class ValidationsForEmail : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var emailAddressAttribute = new EmailAddressAttribute();

            if (value is string email)
            {
                if (string.IsNullOrWhiteSpace(email))
                {
                    return new ValidationResult("This field is required!");
                }

                if (!emailAddressAttribute.IsValid(email))
                {
                    return new ValidationResult("Invalid email address format!");
                }


            }


            return ValidationResult.Success;
        }
    }
}
