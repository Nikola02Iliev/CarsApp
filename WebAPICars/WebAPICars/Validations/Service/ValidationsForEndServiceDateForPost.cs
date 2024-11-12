using System.ComponentModel.DataAnnotations;
using System.Globalization;
using WebAPICars.DTOs.ServiceDTOs;

namespace WebAPICars.Validations.Service
{
    public class ValidationsForEndServiceDateForPost : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var service = (ServicePostDTO)validationContext.ObjectInstance;
            var startServiceDateString = service.StartServiceDate;
            var startServiceDate = DateTime.Parse(startServiceDateString);

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


                if(endServiceDate < startServiceDate || endServiceDate == startServiceDate)
                {
                    return new ValidationResult($"End service date must be later than {startServiceDate:yyyy-MM-dd}");

                }

            }


            return ValidationResult.Success;
        }
    }
}
