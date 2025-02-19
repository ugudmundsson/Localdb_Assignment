using Business.Dtos;
using Data.Interfaces;
using Data.Entities;
using Business.Interfaces;
using Business.Models;
using Data.Repositories;
using Business.Factories;

namespace Business.Services;

public class EmployeesService(IEmployeeRepository employeeRepository) : IEmployeesService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;


    //CREATE-------------------------------------------------
    public async Task<bool> CreateEmployeesAsync(EmployeesRegistrationForm form)
    {
        await _employeeRepository.BeginTransactionAsync();
        try
        {
        var employee = EmployeeFactory.Create(form);
            await _employeeRepository.CommitTransactionAsync();
            await _employeeRepository.SaveChangesAsync();
            var result = await _employeeRepository.CreateAsync(employee);
        return result;

        }
        catch
        {
            await _employeeRepository.RollbackTransactionAsync();
            return false;
        }
    }



    //READ-------------------------------------------------

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        var employees = await _employeeRepository.GetAllAsync();
        
        return EmployeeFactory.Create(employees);
          
    }




    //UPDATE-------------------------------------------------

    public async Task<Employee> UpdateEmployeesAsync(EmployeeUpdateForm form)
    {
        await _employeeRepository.BeginTransactionAsync();
        try
        {
        var employee = await _employeeRepository.GetAsync(x => x.Id == form.Id);
      
        employee = EmployeeFactory.UpdateEntity(employee, form);
            await _employeeRepository.CommitTransactionAsync();
            await _employeeRepository.SaveChangesAsync();
            var result = await _employeeRepository.UpdateAsync(x => x.Id == form.Id, employee);
            
        return EmployeeFactory.Create(employee);

        }
        catch
        {
            await _employeeRepository.RollbackTransactionAsync();
            return null;
        }

    }



    //DELETE-------------------------------------------------

    public async Task<bool> DeleteEmployeesAsync(int id)
    {
        await _employeeRepository.BeginTransactionAsync();
        try
        {
        var contact = await _employeeRepository.GetAsync(x => x.Id == id);
        if (contact == null)
            return false;

        var result = await _employeeRepository.DeleteAsync(x => x.Id == id);
            await _employeeRepository.CommitTransactionAsync();
            await _employeeRepository.SaveChangesAsync();
            return result;

        }
        catch
        {
            await _employeeRepository.RollbackTransactionAsync();
            return false;
        }
    }



}
