using System.ComponentModel.DataAnnotations;
using System.Globalization;
using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;

namespace WebAPICars.Validations.Service
{
    public class ValidationForEndServiceDateForPut : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
 


            if (value is string endServiceDateString)
            {
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
