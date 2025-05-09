using Microsoft.AspNetCore.Mvc;
using DatabaseModels.Models;
using DatabaseModels.DTO;
using AuthenticationService.Interfaces;
//using AuthService.JwtService;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace AuthenticationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        //private readonly JwtToken _jwtToken;
        private readonly IAuthRepository _authenticate;
        public AuthController(IAuthRepository authenticate, string role)
        {
            _authenticate = authenticate;
            //  _jwtToken = jwtToken;
        }

        // Login (Authenticate User)
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginRequest)
        {
            Console.WriteLine($"Received login request: {loginRequest.Username}, {loginRequest.Password}");
            var loggedInUserData = _authenticate.Login(loginRequest);
            if (loggedInUserData == null)
            {
                return Unauthorized(new { message = "Invalid credentials" });
            }

            // var token = _jwtToken.GenerateJwtToken(user.Email);
            return Ok(new { message = "Login successful", username = loggedInUserData.Username, role = loggedInUserData.Role });//, token });
        }


    }
}
