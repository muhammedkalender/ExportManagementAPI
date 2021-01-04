using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.User;
using ExportManagementAPI.Domain.Repositories;

namespace ExportManagementAPI.Infrastructure.Repositories
{
    public class UserRepositoryAsync : IUserRepositoryAsync
    {
        public Task<UserResponseEntity> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<UserInsertResponseEntity> AddAsync(UserInsertRequestEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserUpdateResponseEntity> UpdateAsync(UserUpdateRequestEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserDeleteResponseEntity> DeleteAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserResponseEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserEntity>> FindByCondition(Expression<Func<UserEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}