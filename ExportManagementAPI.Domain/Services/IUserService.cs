using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.User;

namespace ExportManagementAPI.Domain.Services
{
    public interface IUserService
    {
        Task<ResponseEntity<UserResponseEntity>> GetById(Guid guid);
        Task<ResponseEntity<UserInsertResponseEntity>> Insert(UserInsertRequestEntity userInsertRequestEntity);
        Task<ResponseEntity<List<UserResponseEntity>>> All();
        Task<PagedResponseEntity<List<UserResponseEntity>>> Search(UserSearchRequestEntity userSearchRequestEntity);
    }
}