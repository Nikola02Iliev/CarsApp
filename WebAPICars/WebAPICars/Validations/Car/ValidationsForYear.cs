using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Car
{
    public class ValidationsForYear : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return new ValidationResult("This field is required!");
            }

            if (value is int year)
            {
                int currentYear = DateTime.Now.Year;

                if (year == 0)
                {
                    return new ValidationResult("Year can't be zero!");

                }

                if (year < 0)
                {
                    return new ValidationResult("Year can't be negative!");
                }


                if (year > currentYear)
                {
                    return new ValidationResult($"Year can't be greater than {currentYear}.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
