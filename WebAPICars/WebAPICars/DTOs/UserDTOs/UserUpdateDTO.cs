using System.ComponentModel.DataAnnotations;
using WebAPICars.Validations.User;

namespace WebAPICars.DTOs.UserDTOs
{
    public class UserUpdateDTO
    {
        [ValidationsForUsername]
        public string Username { get; set; } = string.Empty;

        [ValidationsForEmail]
        public string Email { get; set; } = string.Empty;
    }
}
