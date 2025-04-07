using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.DTO;
using System.Linq;
using UserService.Context;
using UserService.UserRepository;
using UserService.UserServices;
using Microsoft.EntityFrameworkCore.Metadata;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBasedService _userService;
        public UserController(IUserBasedService userService)
        {
            _userService = userService;
        }

      


        [HttpPost("register")]
        public IActionResult Register([FromBody] UserDto user)
        {
            _userService.RegisterUser(user);
            return Ok("User Registered");
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDto login)
        {
            var user = _userService.AuthenticateUser(login);
            if (user == null) return Unauthorized();

            return Ok(new { token = _userService.GenerateJwtToken(user, login.Username) });
        }



        [HttpGet("profile")]
        [Authorize]
        public IActionResult Profile()
        {
            return Ok("Authorized Profile Info");
        }

        [HttpGet("details/{id}")]
        [Authorize(Roles = "Manager,Admin")]
        public IActionResult GetUserDetails(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpGet("roles")]
        [Authorize]
        public IActionResult GetRoles()
        {
            return Ok(_userService.GetRoles());
        }

        [HttpGet("GetUsers")]
        //[Authorize]
        public IActionResult GetUsers()
        {
            return Ok("For API Testing");
        }




    }

}
