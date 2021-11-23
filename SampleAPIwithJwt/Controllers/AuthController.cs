using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleAPIwithJwt.DTO.User;
using SampleAPIwithJwt.Jwt;
using SampleAPIwithJwt.Jwt.Interface;
using SampleAPIwithJwt.Services.Users;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SampleAPIwithJwt.Controllers
{
    [Authorize]
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _service;
        private IJwtService _jwtToken;

        public AuthController(IUserService service,
            IJwtService jwtToken)
        {
            _service = service;
            _jwtToken = jwtToken;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserDTO user)
        {
            var existingUser = _service.Login(user.Login, user.Password);
            if (existingUser != null)
            {
                var token = await _jwtToken.CreateToken(user.Id);
                return await Task.FromResult(Ok(token));
            }
            else
                return await Task.FromResult(NotFound());
        }

        [HttpGet]
        public async Task<IActionResult> Test()
        {
            return await Task.FromResult(Ok("lalala"));
        }


        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var result = default(List<UserDTO>);
            try
            {
                result = _service.GetAllUsers();
            }
            catch
            {
                throw;
            }
            if (result == null)
                return await Task.FromResult(NoContent());
            else
                return await Task.FromResult(Ok(result));
        }
    }
}
