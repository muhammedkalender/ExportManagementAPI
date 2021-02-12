using System.Net.Mime;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.Authentication;
using ExportManagementAPI.Domain.Services;
using ExportManagementAPI.Web.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExportManagementAPI.Web.Controllers
{
    [Route("api/authentication")]
    public class AuthenticationController : ApiControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        [ProducesResponseType(typeof(ResponseEntity<AuthenticateResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> AuthenticateAsync(AuthenticateRequest authenticateRequest)
        {
            return Ok(await _authenticationService.AuthenticateAsync(authenticateRequest, GenerateIpAddress()));
        }

        [AllowAnonymous]
        [HttpPost("refresh-token")]
        [ProducesResponseType(typeof(ResponseEntity<RefreshTokenResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RefreshToken(RefreshTokenRequest refreshTokenRequest)
        {
            return Ok(await _authenticationService.RefreshTokenAsync(refreshTokenRequest, GenerateIpAddress()));
        }

        [AllowAnonymous]
        [HttpPost("revoke-token")]
        [ProducesResponseType(typeof(ResponseEntity<RevokeTokenResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> RevokeToken(RevokeTokenRequest revokeTokenRequest)
        {
            return Ok(await _authenticationService.RevokeTokenAsync(revokeTokenRequest, GenerateIpAddress()));
        }

        [AllowAnonymous]
        [HttpPost("forgot-password")]
        [ProducesResponseType(typeof(ResponseEntity<ForgotPasswordResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordRequest forgotPasswordRequest)
        {
            return Ok(await _authenticationService.ForgotPassword(forgotPasswordRequest));
        }

        [AllowAnonymous]
        [HttpPost("reset-password")]
        [ProducesResponseType(typeof(ResponseEntity<ResetPasswordResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            return Ok(await _authenticationService.ResetPassword(resetPasswordRequest));
        }

        private string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }

            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}