using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.User;

namespace WebAPICars.DTOs.UserDTOs
{
    public class UserRegisterDTO
    {
        [ValidationsForUsername]
        public string Username {  get; set; } = string.Empty;

        [ValidationsForEmail]
        public string Email {  get; set; } = string.Empty;

        [ValidationsForPassword]
        public string Password { get; set; } = string.Empty;

        [ValidationsForConfirmedPassword]
        public string ConfirmedPassword { get; set; } = string.Empty;
    }
}
