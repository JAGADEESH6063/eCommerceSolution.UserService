using eCommerce.Core.DTO;
using eCommerce.Core.ServiceContracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eCommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService ;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            if (loginRequest == null)
                return BadRequest("Invalid Data");

            AuthenticationResponse? authenticationResponse = await
                _userService.Login(loginRequest);
            if(authenticationResponse == null || !authenticationResponse.Success)
            {
                return Unauthorized("Invalid Creds");
            }

            return Ok(authenticationResponse);
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequest registerRequest)
        {
            if (registerRequest == null)
                return BadRequest("Invalid Data");

            AuthenticationResponse? authenticationResponse = await
                _userService.SignUp(registerRequest);
            if (authenticationResponse == null || !authenticationResponse.Success)
            {
                return BadRequest(authenticationResponse);
            }

            return Ok(authenticationResponse);
        }
    }
}
