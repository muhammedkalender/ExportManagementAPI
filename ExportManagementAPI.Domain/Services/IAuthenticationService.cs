using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.Authentication;

namespace ExportManagementAPI.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseEntity<AuthenticateResponse>> AuthenticateAsync(AuthenticateRequest authenticateRequest,
            string ipAddress);
        Task<ResponseEntity<RefreshTokenResponse>> RefreshTokenAsync(RefreshTokenRequest refreshTokenRequest,
            string ipAddress);
        Task<ResponseEntity<RevokeTokenResponse>> RevokeTokenAsync(RevokeTokenRequest revokeTokenRequest,
            string ipAddress);
        Task<ResponseEntity<ForgotPasswordResponse>> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest);
        Task<ResponseEntity<ResetPasswordResponse>> ResetPassword(ResetPasswordRequest resetPasswordRequest);
    }
}