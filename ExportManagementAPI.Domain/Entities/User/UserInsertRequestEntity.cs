namespace ExportManagementAPI.Domain.Entities.User
{
    public class UserInsertRequestEntity
    {
        public virtual string UserName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
    }
}