using Business.Dtos;
using Data.Interfaces;
using Data.Entities;
using Business.Interfaces;
using Business.Models;
using Data.Repositories;

namespace Business.Services;

public class EmployeesService(IEmployeeRepository employeeRepository) : IEmployeesService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;


    //CREATE-------------------------------------------------
    public async Task<bool> CreateEmployeesAsync(EmployeesRegistrationForm form)
    {
        var employee = new EmployeesEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            RoleId = form.RoleId,
        };
        var result = await _employeeRepository.CreateAsync(employee);
        return result;
    }



    //READ-------------------------------------------------

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        return employees.Select(x => new Employee(x.Id, x.FirstName, x.LastName, x.RoleId));
       
    }




    //UPDATE-------------------------------------------------

    public async Task<Employee> UpdateEmployeesAsync(EmployeeUpdateForm form)
    {
        var employee = await _employeeRepository.GetAsync(x => x.Id == form.Id);
        {
            employee.Id = form.Id;
            employee.FirstName = form.FirstName;
            employee.LastName = form.LastName;
            employee.RoleId = form.RoleId;

            var result = await _employeeRepository.UpdateAsync(x => x.Id == form.Id, employee);
            return new Employee(result.Id, result.FirstName, result.LastName, result.RoleId);
        }
    }



    //DELETE-------------------------------------------------

    public async Task<bool> DeleteEmployeesAsync(int id)
    {
        var contact = await _employeeRepository.GetAsync(x => x.Id == id);
        if (contact == null)
            return false;

        var result = await _employeeRepository.DeleteAsync(x => x.Id == id);
        return result;
    }



}
