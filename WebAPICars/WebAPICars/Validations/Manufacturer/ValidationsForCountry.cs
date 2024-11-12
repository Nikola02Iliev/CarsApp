using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Manufacturer
{
    public class ValidationsForCountry : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string country)
            {
                if (string.IsNullOrWhiteSpace(country)) 
                {
                    return new ValidationResult("This field is required!");
                }

                if (country.Length > 50)
                {
                    return new ValidationResult("This field can't be more than 50 characters!");
                }
            }


            return ValidationResult.Success;
        }
    }
}
