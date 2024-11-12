using System.ComponentModel.DataAnnotations;
using WebAPICars.Services.Implementations;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Validations.Car
{
    public class ValidationsForLicensePlate : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var carService = (ICarService)validationContext.GetService(typeof(ICarService));

            if (carService == null)
            {
                return new ValidationResult("Unable to validate license plate uniqueness.");
            }

            if (value is string licensePlate)
            {
                if (string.IsNullOrWhiteSpace(licensePlate)) 
                {
                    return new ValidationResult("This field is required!");
                }

                if (licensePlate.Length > 10)
                {
                    return new ValidationResult("License plate can't be more than 10 characters!");
                }

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
