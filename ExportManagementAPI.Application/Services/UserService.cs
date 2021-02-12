using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.User;
using ExportManagementAPI.Domain.Exceptions;
using ExportManagementAPI.Domain.Repositories;
using ExportManagementAPI.Domain.Services;
using FluentValidation.Results;

namespace ExportManagementAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepositoryAsync _userRepository;

        public UserService(IUserRepositoryAsync userRepository)
        {
            _userRepository = userRepository;
        }

        public Task<ResponseEntity<List<UserResponseEntity>>> All()
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseEntity<UserResponseEntity>> GetById(Guid guid)
        {
            IList<ValidationFailure> errorMessages = new List<ValidationFailure>();

            if (guid == Guid.Empty)
            {
                errorMessages.Add(new ValidationFailure("id", $"Is not GUID"));

                throw new ValidationException(errorMessages);
            }

            var user = await _userRepository.GetById(guid);

            if (user == null)
            {
                throw new KeyNotFoundException("User not found");
            }

            return new ResponseEntity<UserResponseEntity>(user);
        }

        public async Task<ResponseEntity<UserInsertResponseEntity>> Insert(UserInsertRequestEntity userInsertRequestEntity)
        {
            var user = await _userRepository.AddAsync(userInsertRequestEntity);

            return new ResponseEntity<UserInsertResponseEntity>(user);
        }

        public async Task<PagedResponseEntity<List<UserResponseEntity>>> Search(UserSearchRequestEntity userSearchRequestEntity)
        {
            var users = (await _userRepository.FindByCondition(e =>
                    (e.FirstName.ToLower().Equals(userSearchRequestEntity.FirstName.ToLower()))).ConfigureAwait(false))
                .AsQueryable()
                .FirstOrDefault();

            throw new NotImplementedException();
        }
    }
}