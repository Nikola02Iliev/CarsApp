using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using NuGet.Versioning;
using WebAPICars.DTOs.ManufacturerDTOs;
using WebAPICars.DTOs.UserDTOs;
using WebAPICars.Mappers;
using WebAPICars.Models;
using WebAPICars.Services.Interfaces;

namespace WebAPICars.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        public UsersController(UserManager<AppUser> userManager, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }


        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userManager.Users.Select(u => u.ToUserListDTO()).ToList();

            if (users == null)
            {
                return NotFound("No users found");
            }

            return Ok(users);
        }

        //[Authorize(Roles = "Admin")]
        [HttpGet("{username}")]
        public async Task<ActionResult<UserGetDTO>> GetUser(string username) 
        {
            var user = await _userManager.FindByNameAsync(username);

            var ToUserGetDTO = user.ToUserGetDTO();
            
            return Ok(ToUserGetDTO);
        }


        //[AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterDTO userRegisterDTO)
        {
            var appUser = new AppUser 
            {
                UserName = userRegisterDTO.Username,
                Email = userRegisterDTO.Email
            };

            var createdUser = await _userManager.CreateAsync(appUser, userRegisterDTO.Password);

            if (createdUser.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(appUser, "User");

                if (roleResult.Succeeded) 
                {
                    return Ok(new UserGetDTOAfterRegister
                    {
                        Username = userRegisterDTO.Username,
                        Email = userRegisterDTO.Email,
                        Token = await _tokenService.CreateTokenAsync(appUser)
                    });
                }
                else
                {
                    return BadRequest(roleResult);
                }
            }
            else
            {
                return BadRequest(createdUser);
            }

            
        }

        //[AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDTO userLoginDTO)
        {
            var user = await _userManager.FindByNameAsync(userLoginDTO.Username);

            if (user == null) 
            {
                return Unauthorized("Invalid Username!");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDTO.Password, false);

            if (!result.Succeeded)
            {
                return Unauthorized("Invalid Password!");
            }

            return Ok(new UserGetDTOAfterLogin
            {
                Username = userLoginDTO.Username,
                Email = user.Email,
                Token = await _tokenService.CreateTokenAsync(user)
            });
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("{username}")]
        public async Task<IActionResult> UpdateUser(string username, UserUpdateDTO userUpdateDTO)
        {
            var userModel = await _userManager.FindByNameAsync(username);

            userModel.UserName = userUpdateDTO.Username;
            userModel.Email = userUpdateDTO.Email;

            try
            {
                var result = await _userManager.UpdateAsync(userModel);
                if (!result.Succeeded) 
                {
                    return BadRequest(result);
                }
            }
            catch (DbUpdateConcurrencyException) 
            {
                return Conflict("The record you attempted to edit has been modified by another user. Please reload and try again.");
            }

            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("{username}")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            await _userManager.DeleteAsync(user);

            return NoContent();
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> DeleteAllUsers() 
        {
            var users = await _userManager.Users.ToListAsync();

            foreach (var user in users) 
            {
                await _userManager.DeleteAsync(user);
            }

            return NoContent();
        }

        

    }
}
