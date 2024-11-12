using System.ComponentModel.DataAnnotations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Validations.Owner
{
    public class ValidationsForPhoneNumber : ValidationAttribute
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
                if (string.IsNullOrWhiteSpace(phoneNumber)) 
                {
                    return new ValidationResult("This field is required!");
                }

                if (phoneNumber.Length > 20) 
                {
                    return new ValidationResult("This field can't be more than 20 characters!");
                }

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
