namespace WebAPICars.DTOs.UserDTOs
{
    public class UserGetDTOAfterLogin
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
