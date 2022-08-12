
using BasicAPI.DTOs;
using BasicAPI.Interfaces;
using BasicAPI.Models.Requests;
using BasicAPI.Models.Searchs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace BasicAPI.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[EnableCors("OpenCORSPolicy")]

public class EmployeesController : Controller
{
    public readonly IEmployeeService _employees;

    public EmployeesController(IEmployeeService employees)
    {
        _employees = employees;
    }

    [HttpPost("api/[controller]")]

    public async Task<ActionResult> CreateEmployee(CreateWorkerRequest employee)
    {
        var exist = await _employees.GetEmployee(employee.Identification);
        if (exist != null) return NoContent();
        await _employees.CreateEmployee(employee);
        return Ok();
    }

    [HttpPut("api/[controller]")]
    public async Task<ActionResult> UpdateEmployee(UpdateWorkerRequest employee)
    {
        var exist = await _employees.GetEmployee(employee.Id);

        bool change_in_names = false;

        if (exist == null) return NotFound();
        if (exist.PrimerNombre != employee.FirstName || exist.PrimerApellido != employee.Surname) change_in_names=true;

            exist.Area = employee.Area;
              exist.Correo = employee.Email;
              exist.FechaRegistro = DateTime.Now;
              exist.Identificacion = employee.Identification;
              exist.Pais = employee.Country;
              exist.PrimerApellido = employee.Surname;
              exist.PrimerNombre = employee.FirstName;
              exist.SegundoApellido = employee.SecondSurname;
              exist.SegundoNombre = employee.MiddleName;
              exist.TipoIdentificacion = employee.IdentificationType;
              exist.FechaActualizacion = DateTime.Now;

        await _employees.UpdateEmployee(exist, change_in_names);

        return NoContent();
    }

    [HttpDelete("api/[controller]/{id}")]

    public async Task<ActionResult> DeleteEmployee(int id)
    {
        var exist = await _employees.GetEmployee(id);

        if (exist == null) return NotFound();

        await _employees.DeleteEmployee(id);

        return NoContent();
    }

    [HttpGet("api/[controller]/{id}")]

    public async Task<ActionResult<WorkerDto>> GetEmployee(int id)
    {
        var employee = await _employees.GetEmployee(id);

        if (employee == null) return NotFound();

        return Ok(new WorkerDto
        {
            Area = employee.Area,
            Email = employee.Correo,
            Status = employee.Estado,
            RegistryDate = employee.FechaRegistro,
            Identification = employee.Identificacion,
            Country = employee.Pais,
            Surname = employee.PrimerApellido,
            FirstName = employee.PrimerNombre,
            SecondSurname = employee.SegundoApellido,
            MiddleName = employee.SegundoNombre,
            IdentificationType = employee.TipoIdentificacion,
            Id = employee.Id
        });
    }

    [HttpGet("api/[controller]")]
    public async Task<ActionResult> GetEmployees([FromQuery] EmployeeParams query)
    {
        var employeees = _employees.GetEmployees(query);
        var postList = employeees.Result.Select(employee => new WorkerDto
        {
            Area = employee.Area,
            Email = employee.Correo,
            Status = employee.Estado,
            RegistryDate = employee.FechaRegistro,
            Identification = employee.Identificacion,
            Country = employee.Pais,
            Surname = employee.PrimerApellido,
            FirstName = employee.PrimerNombre,
            SecondSurname = employee.SegundoApellido,
            MiddleName = employee.SegundoNombre,
            IdentificationType = employee.TipoIdentificacion,
            Id = employee.Id
        }).ToList();
        return Ok(postList);
    }

}