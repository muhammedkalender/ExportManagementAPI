using System;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.User;
using ExportManagementAPI.Domain.Services;

namespace ExportManagementAPI.Application.Services
{
    public class UserService : IUserService
    {
        public Task<ResponseEntity<UserResponseEntity>> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseEntity<UserInsertResponseEntity>> Insert(UserInsertRequestEntity userInsertRequestEntity)
        {
            throw new NotImplementedException();
        }
    }
}