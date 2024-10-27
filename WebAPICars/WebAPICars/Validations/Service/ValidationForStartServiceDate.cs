using Microsoft.SqlServer.Server;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPICars.Validations.Service
{
    public class ValidationForStartServiceDate : ValidationAttribute
    {
        
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is string startServiceDateString)
            {
                var currentDateTime = DateTime.Now;
                var currentDateOnly = DateOnly.FromDateTime(currentDateTime);


                bool IsValidFormat = DateTime.TryParseExact(startServiceDateString,
                    "yyyy-MM-dd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime startServiceDate);


                if (!IsValidFormat)
                {
                    return new ValidationResult("Invalid format for start service date! Expected format is yyyy-MM-dd.");
                }

                var startServiceDateOnly = DateOnly.FromDateTime(startServiceDate);

                if (startServiceDateOnly < currentDateOnly)
                {
                    
                    return new ValidationResult($"Start service date must be later than {currentDateOnly:yyyy-MM-dd}");
                }
                
            }

            return ValidationResult.Success;
        }
    }
}
