using System.ComponentModel.DataAnnotations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Validations.Owner
{
    public class ValidationForEmail : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var ownerService = (IOwnerService)validationContext.GetService(typeof(IOwnerService));

            if (ownerService == null) 
            {
                return new ValidationResult("Unable to validate email uniqueness.");
            }

            if(value is string email)
            {
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
