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
    }
}