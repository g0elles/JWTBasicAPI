using GTCapacitorProxy.Interfaces;
using GTCapacitorProxy.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GTCapacitorProxy.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[EnableCors("OpenCORSPolicy")]

public class MiddleWareController : Controller
{
    private readonly IMiddleWareService _middle;

    public MiddleWareController(IMiddleWareService middle)
    {
        _middle = middle;
    }
    
    [HttpPost("api/[controller]")]
    public async Task<object>Post([FromBody] MiddlewareRequest request)
    {
        return await _middle.MiddleRequest(request);
    }
}