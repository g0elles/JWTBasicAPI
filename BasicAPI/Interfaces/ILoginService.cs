using BasicAPI.Models.Requests;

namespace BasicAPI.Interfaces;

public interface ILoginService
{
    bool Authenticate(LoginRequest user);
}