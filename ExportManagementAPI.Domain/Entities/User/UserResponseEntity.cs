using ExportManagementAPI.Domain.Entities.Bases;

namespace ExportManagementAPI.Domain.Entities.User
{
    public class UserResponseEntity : BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
    }
}