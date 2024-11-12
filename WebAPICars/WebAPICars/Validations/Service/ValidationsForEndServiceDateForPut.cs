using System.ComponentModel.DataAnnotations;
using System.Globalization;
using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;

namespace WebAPICars.Validations.Service
{
    public class ValidationsForEndServiceDateForPut : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is string endServiceDateString)
            {
                if (string.IsNullOrWhiteSpace(endServiceDateString))
                {
                    return new ValidationResult("This field is required!");
                }

                bool IsValidFormat = DateTime.TryParseExact(
                    endServiceDateString,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime endServiceDate);

                if (!IsValidFormat)
                {
                    return new ValidationResult("Invalid format for start service date! Expected format is yyyy-MM-dd.");
                }
                

            }

            return ValidationResult.Success;
        }
    }
}
