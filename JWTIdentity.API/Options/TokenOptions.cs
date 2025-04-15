namespace JWTIdentity.API.Options
{
    public class TokenOptions
    {
        public string Issuer { get; set; }
        public string Audience { get; set; }
        public string Key { get; set; }
        public int ExpireInMinutes { get; set; }

    }
}
