using Microsoft.AspNetCore.Mvc;
using Rxlightning.Interface;
using Rxlightning.Models;

namespace Rxlightning.Models
{
    [ApiController]
    [Route("login")]
    [Produces("application/json")]
    public class JwtController : ControllerBase
    {
        private readonly IUserAuth _userService;
        private readonly ILogger<JwtController> _logger;

        public JwtController(IUserAuth userService, ILogger<JwtController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(LoginResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var loginResponse = await _userService.AuthenticateAsync(loginRequest).ConfigureAwait(false);

            if (loginResponse == null)
            {
                return Unauthorized(new { message = "Email or password is incorrect" });
            }

            return Ok(loginResponse);
        }
    }
}