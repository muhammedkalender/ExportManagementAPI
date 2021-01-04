using System;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.Authentication;
using ExportManagementAPI.Domain.Entities.User;
using ExportManagementAPI.Domain.Services;
using ExportManagementAPI.Web.Bases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExportManagementAPI.Web.Controllers.V1
{
    [AllowAnonymous] //TODO
    [Route("api/user")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{guid}")]
        [ProducesResponseType(typeof(ResponseEntity<UserResponseEntity>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ById(Guid guid)
        {
            return Ok(await _userService.GetById(guid));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseEntity<UserInsertResponseEntity>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert(UserInsertRequestEntity userInsertRequestEntity)
        {
            return Ok(await _userService.Insert(userInsertRequestEntity));
        }
    }
}