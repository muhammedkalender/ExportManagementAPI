using System;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.UserToken;

namespace ExportManagementAPI.Domain.Services
{
    public interface IUserTokenService
    {
        Task<ResponseEntity<UserTokenResponseEntity>> GetById(Guid guid);
    }
}