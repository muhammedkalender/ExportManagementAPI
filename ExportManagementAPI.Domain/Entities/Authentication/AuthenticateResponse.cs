namespace ExportManagementAPI.Domain.Entities.Authentication
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}