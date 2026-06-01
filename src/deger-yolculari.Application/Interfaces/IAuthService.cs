using deger_yolculari.Application.DTOs.Auth;
using deger_yolculari.Application.DTOs.Common;

namespace deger_yolculari.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterDto dto);
        Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginDto dto);
        Task<ApiResponse<AuthResponseDto>> RefreshTokenAsync(string refreshToken);
        Task<ApiResponse<bool>> LogoutAsync(Guid userId);
        Task<ApiResponse<bool>> ChangePasswordAsync(Guid userId, ChangePasswordDto dto);
        Task<ApiResponse<bool>> ForgotPasswordAsync(ForgotPasswordDto dto);
        Task<ApiResponse<VerifyResetCodeResponseDto>> VerifyResetCodeAsync(VerifyResetCodeDto dto);
        Task<ApiResponse<bool>> ResetPasswordAsync(ResetPasswordDto dto);
        Task<ApiResponse<UserProfileDto>> GetProfileAsync(Guid userId);
        Task<ApiResponse<UserProfileDto>> UpdateProfileAsync(Guid userId, UpdateProfileDto dto);
    }
}
