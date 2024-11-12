using System.ComponentModel.DataAnnotations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Validations.Manufacturer
{
    public class ValidationsForManufacturerName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            var manufacturerService = (IManufacturerService)validationContext.GetService(typeof(IManufacturerService));

            if (manufacturerService == null)
            {
                return new ValidationResult("Unable to validate manufacturer name uniqueness.");
            }

            
            if (value is string manufacturerName) 
            {
                bool exists = manufacturerService.ManufacturerNameExists(manufacturerName);
                if (exists) 
                {
                    return new ValidationResult($"The manufacturer name '{manufacturerName}' is already taken.");
                }

                if (string.IsNullOrWhiteSpace(manufacturerName))
                {
                    return new ValidationResult("This field is required!");

                }

                if (manufacturerName.Length > 50)
                {
                    return new ValidationResult("This field can't be more than 50 characters!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
