using System.ComponentModel.DataAnnotations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Validations.Owner
{
    public class ValidationForPhoneNumber : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var ownerService = (IOwnerService)validationContext.GetService(typeof(IOwnerService));

            if (ownerService == null) 
            {
                return new ValidationResult("Unable to validate phone number uniqueness.");

            }

            if (value is string phoneNumber)
            {
                bool exists = ownerService.PhoneNumberExists(phoneNumber);
                if (exists) 
                {
                    return new ValidationResult($"The phone number '{phoneNumber}' is already taken.");
                }
                
            }

            return ValidationResult.Success;
        }
    }
}
