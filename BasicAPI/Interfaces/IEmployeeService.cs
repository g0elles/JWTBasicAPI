using BasicAPI.DTOs;
using BasicAPI.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BasicAPI.Interfaces;

public interface IEmployeeService
{
    Task<WorkerDto> CreateEmployee(CreateWorkerRequest employee);
    Task<WorkerDto> UpdateEmployee(UpdateWorkerRequest employee);
    Task<bool> DeleteEmployee(int id);
    Task<List<WorkerDto>> GetEmployees(string query);

    Task<WorkerDto> GetEmployee(int id);
    Task<WorkerDto> GetEmployee(string id);



}