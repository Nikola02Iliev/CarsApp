using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Service
{
    public class ValidationsForServiceDescription : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string serviceDescription)
            {
                if (string.IsNullOrWhiteSpace(serviceDescription))
                {
                    return new ValidationResult("This field is required!");
                }

                if(serviceDescription.Length > 255)
                {
                    return new ValidationResult("Service description can't be more than 255 characters!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
