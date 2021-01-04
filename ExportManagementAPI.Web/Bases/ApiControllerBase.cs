using System.Net.Mime;
using ExportManagementAPI.Domain.Entities.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExportManagementAPI.Web.Bases
{
    [ApiController]
    [ProducesAttribute(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ResponseBadRequestEntity), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseNotFoundEntity), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ResponseUnprocessableEntity), StatusCodes.Status422UnprocessableEntity)]
    [ProducesResponseType(typeof(ResponseInternalServerErrorEntity), StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(typeof(ResponseNotImplementedEntity), StatusCodes.Status501NotImplemented)]
    public class ApiControllerBase : ControllerBase
    {
        protected string GenerateIpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
            {
                return Request.Headers["X-Forwarded-For"];
            }

            return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}