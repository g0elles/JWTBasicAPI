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

    public async Task<List<Funcionario>> GetEmployees(EmployeeParams query)
    {
        IQueryable<Funcionario> funcionarios = _db.Funcionarios;

      //  if(query.FirstName != null) funcionarios.Where()
        throw new NotImplementedException();
    }

    public async Task<Funcionario> UpdateEmployee(Funcionario funcionario,bool change_in_names)
    {
        funcionario.Correo = change_in_names ? _mailService.CreateMail(funcionario.PrimerNombre, funcionario.PrimerApellido, funcionario.Pais) : funcionario.Correo;

        _db.Funcionarios.Update(funcionario);
        await _db.SaveChangesAsync();
        return funcionario;
    }
    
}