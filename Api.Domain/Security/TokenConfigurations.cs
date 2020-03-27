namespace Domain.Security
{
    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public int Issuer { get; set; }
        public int Seconds { get; set; }
    }
}