namespace GTCapacitorProxy.DTOs;

public class LoginDto
{
    public LoginDto()
    {
    }

    public LoginDto(bool success, string token)
    {
        Success = success;
        Token = token;
    }

    public bool Success { get; set; }
    public string Token { get; set; }
}