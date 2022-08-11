using BasicAPI.DTOs;
using BasicAPI.Interfaces;
using BasicAPI.Models.Requests;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers;
[EnableCors("OpenCORSPolicy")]

public class LoginController : Controller
{


    private readonly ILoginService _userService;
    private readonly ITokenService _tkn;

    public LoginController(ILoginService userService, ITokenService tkn)
    {
        _userService = userService;
        _tkn = tkn;
    }

    [HttpPost("api/[controller]")]
    // POST
    public ActionResult<LoginDto> Login([FromBody] LoginRequest login)
    {
        var token = _userService.Authenticate(login) == true ? _tkn.GenerateJwtToken(login) : null;
        return token == null ? Unauthorized() : Ok(new LoginDto { success = true, token = token });
    }
}
