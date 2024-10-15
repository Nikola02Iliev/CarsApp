using System.ComponentModel.DataAnnotations;
using WebAPICars.Services.Implementations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Validations.Car
{
    public class ValidationForLicensePlate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var carService = (ICarService)validationContext.GetService(typeof(ICarService));

            if (carService == null)
            {
                return new ValidationResult("Unable to validate manufacturer name uniqueness.");
            }

            if (value is string licensePlate)
            {
                bool exists = carService.LicensePlateExists(licensePlate);
                if (exists)
                {
                    return new ValidationResult($"The license plate '{licensePlate}' is already taken.");
                }
            }


            return ValidationResult.Success;
        }
    }
}
