using BasicAPI.DTOs;
using BasicAPI.Models.Data;
using BasicAPI.Models.Requests;
using BasicAPI.Models.Searchs;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Interfaces;

public interface IEmployeeService
{
    Task CreateEmployee(CreateWorkerRequest employee);
    Task<Funcionario> UpdateEmployee(Funcionario funcionario, bool change_in_names);
    Task DeleteEmployee(int id);
    Task<List<Funcionario>> GetEmployees(EmployeeParams query);

    Task<Funcionario> GetEmployee(int id);
    Task<Funcionario> GetEmployee(string id);



}