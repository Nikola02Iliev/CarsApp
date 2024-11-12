using WebAPICars.DTOs.UserDTOs;
using WebAPICars.Models;

namespace WebAPICars.Mappers
{
    public static class UserMapper
    {
        public static UserListDTO ToUserListDTO(this AppUser user)
        {
            return new UserListDTO
            {
                Username = user.UserName,
                Email = user.Email
            };
        }

        public static UserGetDTO ToUserGetDTO(this AppUser user) 
        {
            return new UserGetDTO
            {
                Username = user.UserName,
                Email = user.Email
            };
        }

        public static AppUser ToAppUserModel (this UserUpdateDTO userUpdateDTO)
        {
            return new AppUser
            {
                UserName = userUpdateDTO.Username,
                Email = userUpdateDTO.Email
            };
        }
    }
}
