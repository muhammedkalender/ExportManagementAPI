using System;
using System.Collections.Generic;
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
        public async Task<IActionResult> GetById(Guid guid)
        {
            return Ok(await _userService.GetById(guid));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseEntity<UserInsertResponseEntity>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Insert(UserInsertRequestEntity userInsertRequestEntity)
        {
            return Ok(await _userService.Insert(userInsertRequestEntity));
        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseEntity<List<UserEntity>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> All()
        {
            return Ok(await _userService.All());
        }

        [HttpPost("search")]
        [ProducesResponseType(typeof(ResponseEntity<List<UserResponseEntity>>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Search(UserSearchRequestEntity userSearchRequestEntity)
        {
            return Ok(await _userService.Search(userSearchRequestEntity));
        }
    }
}