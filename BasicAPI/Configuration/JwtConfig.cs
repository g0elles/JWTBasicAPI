namespace BasicAPI.Configuration;

public class JwtConfig
{
    public string Secret { get; set; }
    public double Expiration { get; set; }
}