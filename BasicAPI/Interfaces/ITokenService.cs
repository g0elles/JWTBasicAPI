using BasicAPI.Models.Requests;

namespace BasicAPI.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(LoginRequest user);

}