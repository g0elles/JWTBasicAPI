using BasicAPI.DTOs;
using BasicAPI.Interfaces;
using BasicAPI.Models.Data;
using BasicAPI.Models.Requests;
using Microsoft.EntityFrameworkCore;

namespace BasicAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly CidenetDBContext _db;

    public EmployeeService(CidenetDBContext db)
    {
        _db = db;
    }


    public async Task<WorkerDto> CreateEmployee(CreateWorkerRequest employee)
    {
        Funcionario funcionario = new Funcionario
        {
            Area = employee.Area,
            Correo = employee.Email,
            Estado = employee.Status,
            FechaIngreso = employee.RegistryDate,
            FechaRegistro = DateTime.Now,
            Identificacion = employee.Identification,
            Pais = employee.Country,
            PrimerApellido = employee.Surname,
            PrimerNombre = employee.FirstName,
            SegundoApellido = employee.SecondSurname,
            SegundoNombre = employee.MiddleName,
            TipoIdentificacion = employee.IdentificationType
        };
        await _db.Funcionarios.AddAsync(funcionario);
        await _db.SaveChangesAsync();
        return new WorkerDto
        {
            Area = employee.Area,
            Email = employee.Email,
            Status = employee.Status,
            RegistryDate = funcionario.FechaRegistro,
            Identification = employee.Identification,
            Country = employee.Country,
            Surname = employee.Surname,
            FirstName = employee.FirstName,
            SecondSurname = employee.SecondSurname,
            MiddleName = employee.MiddleName,
            IdentificationType = employee.IdentificationType,
            Id = funcionario.Id
        };
    }

    public async Task<bool> DeleteEmployee(int id)
    {
        try
        {
            var employee = await _db.Funcionarios.FindAsync(id);
            _db.Funcionarios.Remove(employee);
            await _db.SaveChangesAsync();
        }
        catch (System.Exception)
        {
            return false;
        }
        return true;
    }

    public async Task<WorkerDto> GetEmployee(int id)
    {
        var employee = await _db.Funcionarios.FindAsync(id);

        return new WorkerDto
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
        };
    }

    public async Task<WorkerDto> GetEmployee(string id)
    {
        var employee = await _db.Funcionarios.Where(x => x.Identificacion.Equals(id)).FirstAsync();

        return new WorkerDto
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
        };
    }

    public async Task<List<WorkerDto>> GetEmployees(string query)
    {
        throw new NotImplementedException();
    }

    public async Task<WorkerDto> UpdateEmployee(UpdateWorkerRequest employee)
    {
        Funcionario funcionario = new Funcionario
        {
            Area = employee.Area,
            Correo = employee.Email,
            Estado = employee.Status,
            FechaRegistro = DateTime.Now,
            Identificacion = employee.Identification,
            Pais = employee.Country,
            PrimerApellido = employee.Surname,
            PrimerNombre = employee.FirstName,
            SegundoApellido = employee.SecondSurname,
            SegundoNombre = employee.MiddleName,
            TipoIdentificacion = employee.IdentificationType,
            FechaActualizacion = DateTime.Now
        };
        _db.Funcionarios.Update(funcionario);
        await _db.SaveChangesAsync();
        return new WorkerDto
        {
            Area = employee.Area,
            Email = employee.Email,
            Status = employee.Status,
            RegistryDate = funcionario.FechaRegistro,
            Identification = employee.Identification,
            Country = employee.Country,
            Surname = employee.Surname,
            FirstName = employee.FirstName,
            SecondSurname = employee.SecondSurname,
            MiddleName = employee.MiddleName,
            IdentificationType = employee.IdentificationType,
            Id = funcionario.Id
        };
    }
}