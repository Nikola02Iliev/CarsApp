using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Car
{
    public class ValidationsForPrice : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if(value == null)
            {
                return new ValidationResult("This field is required!");
            }

            if (value is decimal price)
            {
                if (price == 0)
                {
                    return new ValidationResult("Price can't be zero!");
                }

                if (price < 0)
                {
                    return new ValidationResult("Price can't be negative number!");
                }

            }

            return ValidationResult.Success;
        }
    }
}
