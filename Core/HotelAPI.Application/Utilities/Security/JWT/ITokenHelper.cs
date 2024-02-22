using System.Security.Claims;
namespace HotelAPI.Application.Utilities.Security.JWT;

public interface ITokenHelper
{
    //AccessToken CreateToken(List<Claim> claim);
    string GenerateJwt(TokenOptions tokenOptions);

}
