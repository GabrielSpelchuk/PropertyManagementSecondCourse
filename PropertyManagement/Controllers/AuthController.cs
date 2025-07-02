using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PropertyManagement.BLL.Dtos.Auth;
using PropertyManagement.BLL.Exceptions;
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

        /// <summary>
        /// Register a new user.
        /// </summary>
        /// <param name="dto">User registration data</param>
        /// <returns>201 Created if successful</returns>
        /// <response code="201">User created successfully</response>
        /// <response code="400">Invalid data</response>
        [HttpPost("register")]
        [AllowAnonymous]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var success = await _jwtService.RegisterAsync(dto.UserName, dto.Email, dto.Password);
            if (!success)
                throw new BadRequestException("User already exists or invalid data.");

            return StatusCode(201);
        }

        /// <summary>
        /// Confirm user email.
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="token">Email confirmation token</param>
        /// <returns>200 OK if confirmed</returns>
        [HttpGet("confirm-email")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string userId, [FromQuery] string token)
        {
            var result = await _jwtService.ConfirmEmailAsync(userId, token);
            if (!result)
                throw new BadRequestException("Invalid or expired confirmation token.");

            return Ok("Email confirmed!");
        }

        /// <summary>
        /// Log in an existing user.
        /// </summary>
        /// <param name="dto">Login credentials</param>
        /// <returns>Access and Refresh tokens</returns>
        [HttpPost("login")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            try
            {
                var (accessToken, refreshToken) = await _jwtService.LoginAsync(dto.Email, dto.Password);
                return Ok(new { accessToken, refreshToken });
            }
            catch
            {
                throw new UnauthorizedException("Invalid credentials or email not confirmed.");
            }
        }

        /// <summary>
        /// Refresh access token using refresh token.
        /// </summary>
        /// <param name="dto">Refresh token pair</param>
        /// <returns>New token pair</returns>
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Refresh([FromBody] RefreshDto dto)
        {
            try
            {
                var (accessToken, refreshToken) = await _jwtService.RefreshTokenAsync(dto.AccessToken, dto.RefreshToken);
                return Ok(new { accessToken, refreshToken });
            }
            catch
            {
                throw new UnauthorizedException("Invalid refresh attempt.");
            }
        }

        /// <summary>
        /// Request password reset link.
        /// </summary>
        /// <param name="dto">User email</param>
        /// <returns>200 OK if found</returns>
        [HttpPost("forgot-password")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var success = await _jwtService.ForgotPasswordAsync(dto.Email);
            if (!success)
                throw new NotFoundException("User not found.");

            return Ok("Reset link sent.");
        }

        /// <summary>
        /// Reset user password.
        /// </summary>
        /// <param name="dto">Reset password data</param>
        /// <returns>200 OK if success</returns>
        [HttpPost("reset-password")]
        [AllowAnonymous]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var success = await _jwtService.ResetPasswordAsync(dto.Email, dto.Token, dto.NewPassword);
            if (!success)
                throw new BadRequestException("Reset failed. Check token or password format.");

            return Ok("Password changed.");
        }

        /// <summary>
        /// Get authenticated user info.
        /// </summary>
        /// <returns>User info</returns>
        [Authorize]
        [HttpGet("me")]
        [ProducesResponseType(200)]
        public IActionResult Me()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var email = User.FindFirstValue(ClaimTypes.Email);
            var roles = User.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();

            return Ok(new { id, email, roles });
        }

        /// <summary>
        /// Log out current user.
        /// </summary>
        /// <returns>200 OK</returns>
        [Authorize]
        [HttpPost("logout")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Logout()
        {
            await _jwtService.LogoutAsync();
            return Ok(new { message = "Logged out." });
        }
    }
}
