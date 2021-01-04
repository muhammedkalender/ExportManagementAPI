using System.ComponentModel.DataAnnotations;

namespace ExportManagementAPI.Domain.Entities.Authentication
{
    public class AuthenticateRequest
    {
        [Required] [EmailAddress] public string UserName { get; set; }

        [Required] public string Password { get; set; }
    }
}