using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Manufacturer
{
    public class ValidationsForEstablishedYear : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("This field is required.");
            }

            if (value is int establishedYear)
            {

                int currentYear = DateTime.Now.Year;

                if (establishedYear == 0)
                {
                    return new ValidationResult("Established year can't be zero!");

                }

                if (establishedYear < 0)
                {
                    return new ValidationResult("Established year can't be negative!");
                }


                if (establishedYear > currentYear)
                {
                    return new ValidationResult($"Year cannot be greater than {currentYear}.");
                }

            }

            return ValidationResult.Success;
        }


    }
}
