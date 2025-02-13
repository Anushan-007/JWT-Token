using System.Security.Claims;
using LoginSystemManagement.DTOs.Request;
using LoginSystemManagement.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoginSystemManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("userRegister")]
        public async Task<IActionResult> UserRegister(UserRequest userRequest)
        {
            try
            {
                var data = await _userService.UserRegister(userRequest);
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            try
            {
                var loginResponse = await _userService.UserLogin(loginRequest);
                return Ok(loginResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }

        //[Authorize(Roles = "Admin")]
        //[HttpGet]
        //public async Task<IActionResult> GetAllUsers()
        //{
        //    var user = HttpContext.User;
        //    var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();

        //    if (!roles.Contains("Admin"))
        //    {
        //        return Forbid(); // Debugging check
        //    }

        //    var users = await _userService.GetAllUsers();
        //    return Ok(users);
        //}


    }
}
