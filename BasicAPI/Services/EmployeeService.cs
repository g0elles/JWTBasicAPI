using BasicAPI.DTOs;
using BasicAPI.Interfaces;
using BasicAPI.Models.Data;
using BasicAPI.Models.Requests;
using BasicAPI.Models.Searchs;
using Microsoft.EntityFrameworkCore;

namespace BasicAPI.Services;

public class EmployeeService : IEmployeeService
{
    private readonly CidenetDBContext _db;
    private readonly IMailService _mailService;

    public EmployeeService(CidenetDBContext db, IMailService mailService)
    {
        _db = db;
        _mailService = mailService;
    }


    public async Task CreateEmployee(CreateWorkerRequest employee)
    {
        string email = _mailService.CreateMail(employee.FirstName, employee.Surname, employee.Country);
        Funcionario funcionario = new Funcionario
        {
            Area = employee.Area,
            Correo = email,
            Estado = employee.Status,
            FechaIngreso = employee.EntryDate,
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
    }

    public async Task DeleteEmployee(int id)
    {
        var employee = await _db.Funcionarios.FindAsync(id);
        if (employee != null)
            _db.Funcionarios.Remove(employee); await _db.SaveChangesAsync();
    }

    public async Task<Funcionario> GetEmployee(int id)
    {
        return await _db.Funcionarios.Where(x => x.Id == id).FirstOrDefaultAsync();
    }

    public async Task<Funcionario> GetEmployee(string id)
    {
        return await _db.Funcionarios.Where(x => x.Identificacion.Equals(id)).FirstOrDefaultAsync();
    }

    public async Task<List<Funcionario>> GetEmployees(EmployeeParams query = null)
    {
      var funcionarios = _db.Funcionarios.AsQueryable();

      funcionarios = AddFiltersOnQuery(query, funcionarios);
      return await funcionarios.ToListAsync();
    }



    public async Task<Funcionario> UpdateEmployee(Funcionario funcionario,bool change_in_names)
    {
        funcionario.Correo = change_in_names ? _mailService.CreateMail(funcionario.PrimerNombre, funcionario.PrimerApellido, funcionario.Pais) : funcionario.Correo;

        _db.Funcionarios.Update(funcionario);
        await _db.SaveChangesAsync();
        return funcionario;
    }
    
    private static IQueryable<Funcionario> AddFiltersOnQuery(EmployeeParams query, IQueryable<Funcionario> funcionarios)
    {
        if (!String.IsNullOrEmpty(query?.FirstName))
        {
            funcionarios = funcionarios.Where(x => x.PrimerNombre == query.FirstName);
        }
        if (!String.IsNullOrEmpty(query?.MiddleName))
        {
            funcionarios = funcionarios.Where(x => x.SegundoNombre == query.MiddleName);
        }
        if (!String.IsNullOrEmpty(query?.Surname))
        {
            funcionarios = funcionarios.Where(x => x.PrimerApellido == query.Surname);
        }
        if (!String.IsNullOrEmpty(query?.SecondSurname))
        {
            funcionarios = funcionarios.Where(x => x.SegundoApellido == query.SecondSurname);
        }
        if (!String.IsNullOrEmpty(query?.IdentificationType))
        {
            funcionarios = funcionarios.Where(x => x.TipoIdentificacion == query.IdentificationType);
        }
        if (!String.IsNullOrEmpty(query?.Identification))
        {
            funcionarios = funcionarios.Where(x => x.Identificacion == query.Identification);
        }
        if (!String.IsNullOrEmpty(query?.Email))
        {
            funcionarios = funcionarios.Where(x => x.Correo == query.Email);
        }
        if (!String.IsNullOrEmpty(query?.Country))
        {
            funcionarios = funcionarios.Where(x => x.Pais == query.Country);
        }
        return funcionarios;
    }
    
}