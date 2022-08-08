using GTCapacitorProxy.Models;

namespace GTCapacitorProxy.Interfaces;

public interface ILoginService
{
    bool Authenticate(LoginRequest user);
}