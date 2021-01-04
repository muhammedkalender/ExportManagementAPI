using System;
using System.Collections.Generic;
using ExportManagementAPI.Domain.Entities.Bases;
using ExportManagementAPI.Domain.Entities.UserStatus;
using ExportManagementAPI.Domain.Entities.UserToken;

namespace ExportManagementAPI.Domain.Entities.User
{
    public class UserEntity : StandardEntity
    {
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        public virtual UserStatusEntity Status { get; set; }
        public virtual List<UserTokenEntity> Tokens { get; set; }
    }
}