using System.ComponentModel.DataAnnotations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Validations.Owner
{
    public class ValidationsForEmail : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            
            var ownerService = (IOwnerService)validationContext.GetService(typeof(IOwnerService));

            var emailAddressAttribute = new EmailAddressAttribute();

            if (ownerService == null) 
            {
                return new ValidationResult("Unable to validate email uniqueness.");
            }

            if(value is string email)
            {
                if (string.IsNullOrWhiteSpace(email)) 
                {
                    return new ValidationResult("This field is required!");
                }

                if (email.Length > 50)
                {
                    return new ValidationResult("This field can't be more than 50 characters!");
                }

                if (!emailAddressAttribute.IsValid(email)) 
                {
                    return new ValidationResult("Invalid email address format!");
                }
                

                bool exists = ownerService.EmailExists(email);
                if (exists) 
                {
                    return new ValidationResult($"The email '{email}' is already taken.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
