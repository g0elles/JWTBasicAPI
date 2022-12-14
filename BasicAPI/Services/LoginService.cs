using BasicAPI.Configuration;
using BasicAPI.Interfaces;
using BasicAPI.Models.Requests;
using Microsoft.Extensions.Options;

namespace BasicAPI.Services;

public class LoginService : ILoginService
{
    private readonly AuthUsers _users;

    public LoginService(IOptionsMonitor<AuthUsers> optionsMonitor)
    {
        _users = optionsMonitor.CurrentValue;
    }

    public bool Authenticate(LoginRequest user)
    {
        return (user.Username.Equals(Decrypt(_users.user)) && user.Password.Equals(Decrypt(_users.password)));
    }

    private static string Decrypt(string cipher)
    {
        var data = System.Convert.FromBase64String(cipher);
        var base64Decoded = System.Text.Encoding.ASCII.GetString(data);
        return base64Decoded;
    }
}