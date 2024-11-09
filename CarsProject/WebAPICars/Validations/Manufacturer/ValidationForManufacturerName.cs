using System.ComponentModel.DataAnnotations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Validations.Manufacturer
{
    public class ValidationForManufacturerName : ValidationAttribute
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
            }

            return ValidationResult.Success;
        }
    }
}
