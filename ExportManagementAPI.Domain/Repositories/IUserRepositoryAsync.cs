using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.User;

namespace ExportManagementAPI.Domain.Repositories
{
    public interface IUserRepositoryAsync
    {
        Task<UserResponseEntity> GetById(Guid guid);
        Task<UserInsertResponseEntity> AddAsync(UserInsertRequestEntity entity);
        Task<UserUpdateResponseEntity> UpdateAsync(UserUpdateRequestEntity entity);
        Task<UserDeleteResponseEntity> DeleteAsync(Guid guid);
        Task<IEnumerable<UserResponseEntity>> GetAllAsync();
        Task<IEnumerable<UserEntity>> FindByCondition(
            Expression<Func<UserEntity, bool>> expression);
    }
}