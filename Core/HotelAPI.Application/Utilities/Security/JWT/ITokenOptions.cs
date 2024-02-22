namespace HotelAPI.Application.Utilities.Security.JWT;

public interface ITokenOptions
{
    public string Issuer { get; set; }
    public string Auidence { get; set; }
    public int AccessTokenExpiration { get; set; }
    public string SecurityKey { get; set; }
}

