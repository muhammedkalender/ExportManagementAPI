using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.UserToken;
using ExportManagementAPI.Domain.Repositories;

namespace ExportManagementAPI.Infrastructure.Repositories
{
    public class UserTokenRepositoryAsync : IUserTokenRepositoryAsync
    {
        public Task<UserTokenResponseEntity> GetById(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<UserTokenInsertResponseEntity> AddAsync(UserTokenInsertRequestEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserTokenUpdateResponseEntity> UpdateAsync(UserTokenUpdateRequestEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<UserTokenDeleteResponseEntity> DeleteAsync(Guid guid)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserTokenResponseEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserTokenEntity>> FindByCondition(Expression<Func<UserTokenEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }
    }
}