using System;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.User;

namespace ExportManagementAPI.Domain.Services
{
    public interface IUserService
    {
        Task<ResponseEntity<UserResponseEntity>> GetById(Guid guid);
    }
}