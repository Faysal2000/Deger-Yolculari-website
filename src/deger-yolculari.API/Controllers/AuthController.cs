using System.Security.Claims;
using deger_yolculari.Application.DTOs.Auth;
using deger_yolculari.Application.DTOs.Common;
using deger_yolculari.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace deger_yolculari.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<AuthResponseDto>>> Register([FromBody] RegisterDto dto)
        {
            var result = await _authService.RegisterAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResponseDto>>> Login([FromBody] LoginDto dto)
        {
            var result = await _authService.LoginAsync(dto);
            return result.Success ? Ok(result) : Unauthorized(result);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<ApiResponse<AuthResponseDto>>> Refresh([FromBody] RefreshTokenDto dto)
        {
            var result = await _authService.RefreshTokenAsync(dto.RefreshToken);
            return result.Success ? Ok(result) : Unauthorized(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> Logout()
        {
            var userId = GetCurrentUserId();
            var result = await _authService.LogoutAsync(userId);
            return Ok(result);
        }

        [HttpGet("profile")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<UserProfileDto>>> GetProfile()
        {
            var userId = GetCurrentUserId();
            var result = await _authService.GetProfileAsync(userId);
            return result.Success ? Ok(result) : NotFound(result);
        }

        [HttpPut("profile")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<UserProfileDto>>> UpdateProfile([FromBody] UpdateProfileDto dto)
        {
            var userId = GetCurrentUserId();
            var result = await _authService.UpdateProfileAsync(userId, dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut("change-password")]
        [Authorize]
        public async Task<ActionResult<ApiResponse<bool>>> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var userId = GetCurrentUserId();
            var result = await _authService.ChangePasswordAsync(userId, dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("forgot-password")]
        public async Task<ActionResult<ApiResponse<bool>>> ForgotPassword([FromBody] ForgotPasswordDto dto)
        {
            var result = await _authService.ForgotPasswordAsync(dto);
            return Ok(result);
        }

        [HttpPost("verify-reset-code")]
        public async Task<ActionResult<ApiResponse<VerifyResetCodeResponseDto>>> VerifyResetCode([FromBody] VerifyResetCodeDto dto)
        {
            var result = await _authService.VerifyResetCodeAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<ApiResponse<bool>>> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var result = await _authService.ResetPasswordAsync(dto);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        private Guid GetCurrentUserId()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Guid.TryParse(claim, out var id) ? id : throw new UnauthorizedAccessException();
        }
    }
}
