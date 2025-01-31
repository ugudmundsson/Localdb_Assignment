using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IEmployeesService
    {
        Task<bool> CreateEmployeesAsync(EmployeesRegistrationForm form);
        Task<IEnumerable<Employee>> GetEmployeesAsync();
        Task<Employee> UpdateEmployeesAsync(EmployeeUpdateForm form);
        Task<bool> DeleteEmployeesAsync(int id);
    }
}