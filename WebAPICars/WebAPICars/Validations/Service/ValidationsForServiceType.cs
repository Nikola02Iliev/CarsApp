using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Service
{
    public class ValidationsForServiceType : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string serviceType)
            {
                if (string.IsNullOrWhiteSpace(serviceType))
                {
                    return new ValidationResult("This field is required!");
                }

                if (serviceType.Length > 30)
                {
                    return new ValidationResult("Service type can't be more than 30 characters!");
                }

            }

            return ValidationResult.Success;
        }
    }
}
