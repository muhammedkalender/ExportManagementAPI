using System;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.UserToken;
using ExportManagementAPI.Domain.Services;

namespace ExportManagementAPI.Application.Services
{
    public class UserTokenService:IUserTokenService
    {
        public Task<ResponseEntity<UserTokenResponseEntity>> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}