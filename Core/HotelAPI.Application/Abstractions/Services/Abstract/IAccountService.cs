using HotelAPI.Application.DTOs;
using HotelAPI.Application.Utilities.Security.JWT;
using System.Security.Claims;

namespace HotelAPI.Application.Abstractions.Services.Abstract;
public interface IAccountService
{
    #region Auth Requests
    Task<IDataResult<UserGetDto>> Register(RegisterDto registerDto);
    Task<IDataResult<UserGetDto>> Login(LoginDto loginDto);
    //Task<IDataResult<AccessToken>> CreateAccessToken(AppUser user);
    #endregion

    #region Get Requests

    Task<IDataResult<List<UserGetDto>>> GetAllUser(params string[] includes);
    Task<IDataResult<List<UserGetDto>>> GetAllUserByRole(string role, params string[] includes);
    Task<IDataResult<UserGetDto>> GetUserById(string id, params string[] includes);
    Task<IDataResult<UserGetDto>> GetUserByClaims(ClaimsPrincipal userClaims, params string[] includes);
    #endregion


    Task<IResult> EvokeUserToAdmin(UserGetDto dto);
    Task<IResult> RevokeFromAdmin(UserGetDto dto);
}
