using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.User;
using ExportManagementAPI.Domain.Entities.UserToken;

namespace ExportManagementAPI.Domain.Repositories
{
    public interface IUserTokenRepositoryAsync
    {
        Task<UserTokenResponseEntity> GetById(Guid guid);
        Task<UserTokenInsertResponseEntity> AddAsync(UserTokenInsertRequestEntity entity);
        Task<UserTokenUpdateResponseEntity> UpdateAsync(UserTokenUpdateRequestEntity entity);
        Task<UserTokenDeleteResponseEntity> DeleteAsync(Guid guid);
        Task<IEnumerable<UserTokenResponseEntity>> GetAllAsync();

        Task<IEnumerable<UserTokenEntity>> FindByCondition(
            Expression<Func<UserTokenEntity, bool>> expression);
    }
}