using ExportManagementAPI.Domain.Enums;

namespace ExportManagementAPI.Domain.Entities.UserStatus
{
    public class UserStatusEntity
    {
        public virtual string Description { get; set; }
        public virtual UserStatusEnum Type { get; set; }
    }
}