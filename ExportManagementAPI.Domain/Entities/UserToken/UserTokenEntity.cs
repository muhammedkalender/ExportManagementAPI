using System;
using ExportManagementAPI.Domain.Entities.Bases;

namespace ExportManagementAPI.Domain.Entities.UserToken
{
    public class UserTokenEntity : StandardEntity
    {
        public virtual Guid UserId { get; set; }
        public virtual string Token { get; set; }
        public virtual string JwtToken { get; set; }
        public virtual DateTime ExpireDate { get; set; }
        public virtual bool IsExpired => DateTime.UtcNow >= ExpireDate;
        public virtual string ReplacedByToken { get; set; }
        public virtual string InsertIp { get; set; }
        public virtual string? UpdateIp { get; set; }
        public virtual bool IsActive => UpdateDate == null && !IsExpired;
    }
}