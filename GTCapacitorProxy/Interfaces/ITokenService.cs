using GTCapacitorProxy.Models;

namespace GTCapacitorProxy.Interfaces;

public interface ITokenService
{
    string GenerateJwtToken(LoginRequest user);
   
}