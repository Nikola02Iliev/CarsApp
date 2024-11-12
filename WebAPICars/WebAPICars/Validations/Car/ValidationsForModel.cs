using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Car
{
    public class ValidationsForModel : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {

            if (value is string model) 
            {
                if (string.IsNullOrWhiteSpace(model)) 
                {
                    return new ValidationResult("This field is required!");
                }

                if(model.Length > 30)
                {
                    return new ValidationResult("Model can't be more than 30 characters!");
                }
            }

            return ValidationResult.Success;
        }
    }
}
