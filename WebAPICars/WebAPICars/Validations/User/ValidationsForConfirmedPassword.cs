using System.ComponentModel.DataAnnotations;
using WebAPICars.DTOs.ServiceDTOs;
using WebAPICars.DTOs.UserDTOs;

namespace WebAPICars.Validations.User
{
    public class ValidationsForConfirmedPassword : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var user = (UserRegisterDTO)validationContext.ObjectInstance;

            if (value is string confirmedPassword)
            {
                if (string.IsNullOrWhiteSpace(confirmedPassword)) 
                {
                    return new ValidationResult("This field is required!");
                }

                if (confirmedPassword != user.Password) 
                {
                    return new ValidationResult("Confirmed password does not match with password!");
                }
            }


            return ValidationResult.Success;
        }
    }
}
