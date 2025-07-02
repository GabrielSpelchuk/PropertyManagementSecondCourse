using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.BLL.Dtos.Auth;
using PropertyManagement.BLL.Services.Interfaces;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PropertyManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var success = await _jwtService.RegisterAsync(dto.UserName, dto.Email, dto.Password);
            if (!success) return Conflict("User already exists or invalid data.");
            return StatusCode(201);
        }

        [HttpGet("confirm-email")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
        {
            var result = await _jwtService.ConfirmEmailAsync(userId, token);
            return result ? Ok("Email confirmed!") : BadRequest("Invalid or expired token.");
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var (accessToken, refreshToken) = await _jwtService.LoginAsync(dto.Email, dto.Password);
                return Ok(new { accessToken, refreshToken });
            }
            catch
            {
                return Unauthorized("Invalid credentials or email not confirmed.");
            }
        }

        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> Refresh([FromBody] RefreshDto dto)
        {
            try
            {
                var (accessToken, refreshToken) = await _jwtService.RefreshTokenAsync(dto.AccessToken, dto.RefreshToken);
                return Ok(new { accessToken, refreshToken });
            }
            catch
            {
                return Unauthorized("Invalid refresh attempt.");
            }
        }

        [HttpPost("forgot-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var success = await _jwtService.ForgotPasswordAsync(dto.Email);
            return success ? Ok("Reset link sent.") : NotFound("User not found.");
        }

        [HttpPost("reset-password")]
        [AllowAnonymous]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var success = await _jwtService.ResetPasswordAsync(dto.Email, dto.Token, dto.NewPassword);
            return success ? Ok("Password changed.") : BadRequest("Reset failed.");
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult Me()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

            return Ok(new { id, email, roles });
        }

        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _jwtService.LogoutAsync();
            return Ok(new { message = "Logged out." });
        }
    }
}
