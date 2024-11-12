using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Owner
{
    public class ValidationsForAge : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null) 
            {
                return new ValidationResult("This field is required!");
            }

            if (value is int age)
            {

                if (age == 0)
                {
                    return new ValidationResult("Age can't be zero!");
                }

                if (age < 0)
                {
                    return new ValidationResult("Age can't be negative!");
                }

                if (age < 18)
                {
                    return new ValidationResult("Age must be greater than or equal to 18");
                }

            }

            return ValidationResult.Success;
        }
    }
}
