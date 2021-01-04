namespace ExportManagementAPI.Domain.Entities.Config
{
    public class JwtConfig
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public short DurationInMinutes { get; set; }
        public short TokenLifetimeInMinute { get; set; }
    }
}