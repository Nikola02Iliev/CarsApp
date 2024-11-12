using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.User;

namespace WebAPICars.DTOs.UserDTOs
{
    public class UserLoginDTO
    {
        [ValidationsForUsername]
        public string Username { get; set; } = string.Empty;

        [ValidationsForPassword]
        public string Password { get; set; } = string.Empty;
    }
}
