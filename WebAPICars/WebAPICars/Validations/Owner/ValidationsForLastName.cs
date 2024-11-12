using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Owner
{
    public class ValidationsForLastName : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is string lastName)
            {
                if (string.IsNullOrWhiteSpace(lastName))
                {
                    return new ValidationResult("This field is required!");
                }

                if (lastName.Length > 50)
                {
                    return new ValidationResult("This field can't be more than 50 characters!");
                }
   
            }

            return ValidationResult.Success;
        }
    }
}
