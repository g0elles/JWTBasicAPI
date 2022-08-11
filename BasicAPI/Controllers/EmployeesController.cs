
using BasicAPI.DTOs;
using BasicAPI.Interfaces;
using BasicAPI.Models.Requests;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[EnableCors("OpenCORSPolicy")]
public class EmployeesControler : Controller
{
    public readonly IEmployeeService _employees;

    public EmployeesControler(IEmployeeService employees)
    {
        _employees = employees;
    }

    public Task<ActionResult<WorkerDto>> CreateEmployee(CreateWorkerRequest employee)
    {
        var exist = _employees.find    
        
        
    }

}