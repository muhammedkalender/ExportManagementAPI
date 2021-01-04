using System.Net.Mime;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.Authentication;
using ExportManagementAPI.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExportManagementAPI.Web.Controllers
{
    [ApiController]
    [Route("api/authentication")]
    [ProducesAttribute(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ResponseBadRequestEntity), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseNotFoundEntity), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseUnprocessableEntity), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ResponseInternalServerErrorEntity), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ResponseNotImplementedEntity), StatusCodes.Status501NotImplemented)]
    public class AuthenticationController : ControllerBase
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