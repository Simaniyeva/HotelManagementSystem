using HotelAPI.Application.Utilities.Security.Encryption;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HotelAPI.Application.Utilities.Security.JWT;

public class JWTHelper : ITokenHelper
{
    //private readonly IConfiguration _configuration;
    //private TokenOptions _tokenOption;
    //private DateTime _accessTokenExp;

    //public JWTHelper(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //    _tokenOption = _configuration.GetSection("TokenOptions").Get<TokenOptions>();
    //    _accessTokenExp = DateTime.UtcNow.AddMinutes(_tokenOption.AccessTokenExpiration);
    //}
    //public AccessToken CreateToken(List<Claim> claims)
    //{
    //    JwtHeader header = CreateJwtHeader(_tokenOption);
    //    JwtPayload payload = CreateJwtPayload(_tokenOption, claims);
    //    JwtSecurityToken securityToken = CreateJwtSecurityToken(header, payload);
    //    string token = new JwtSecurityTokenHandler().WriteToken(securityToken);
    //    return new AccessToken
    //    {
    //        Token = token,
    //        Expiration = _accessTokenExp

    //    };
    //}


    //#region Private Methods

    //private JwtHeader CreateJwtHeader(TokenOptions options)
    //{
    //    SecurityKey securityKey = SecurityKeyHelper.CreateSecurityKey(options.SecurityKey);
    //    SigningCredentials credentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
    //    return new JwtHeader(credentials);
    //}
    //private JwtPayload CreateJwtPayload(TokenOptions options, List<Claim> claims)
    //{
    //    return new JwtPayload(options.Issuer, options.Auidence, claims, DateTime.UtcNow, _accessTokenExp);
    //}
    //private JwtSecurityToken CreateJwtSecurityToken(JwtHeader header, JwtPayload payload)
    //{
    //    return new JwtSecurityToken(header, payload);
    //}
    //#endregion


    public string GenerateJwt(TokenOptions tokenOptions)
    {
        //List<Claim> claims = new List<Claim>
        //                {
        //                    new Claim(JwtRegisteredClaimNames.Sub, userModelForTokenGen.Id.ToString()),
        //                    new Claim(ClaimTypes.Name, userModelForTokenGen.UserName),
        //                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        //                    new Claim(ClaimTypes.NameIdentifier, userModelForTokenGen.Id.ToString())
        //                };

        //IEnumerable<Claim> roleClaims = roles.Select(r => new Claim(ClaimTypes.Role, r));
        //claims.AddRange(roleClaims);

        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        DateTime accessTokenExpiration = DateTime.Now.AddYears(Convert.ToInt32(tokenOptions.AccessTokenExpiration));

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: tokenOptions.Issuer,
            audience: tokenOptions.Auidence,
            claims: null,
            expires: accessTokenExpiration,
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
