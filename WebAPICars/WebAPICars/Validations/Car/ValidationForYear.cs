using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Car
{
    public class ValidationForYear : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int year)
            {
                int currentYear = DateTime.Now.Year;

                if (year < 0)
                {
                    return new ValidationResult("Year cannot be negative");
                }


                if (year > currentYear)
                {
                    return new ValidationResult($"Year cannot be greater than {currentYear}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
