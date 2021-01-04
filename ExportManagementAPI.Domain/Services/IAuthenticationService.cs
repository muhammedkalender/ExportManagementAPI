using System.Threading.Tasks;
using ExportManagementAPI.Domain.Entities.API;
using ExportManagementAPI.Domain.Entities.Authentication;

namespace ExportManagementAPI.Domain.Services
{
    public interface IAuthenticationService
    {
        Task<ResponseEntity<AuthenticateResponse>> AuthenticateAsync(AuthenticateRequest authenticateRequest,
            string ipAddress);
    }
}