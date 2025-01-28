using Business.Interfaces;
using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class EmployeesService(DataContext context) : IEmployeesService
{

    private readonly DataContext _context = context;


    public EmployeesEntity CreateEmployees(EmployeesEntity employeesEntity)
    {

        _context.Employees.Add(employeesEntity);
        _context.SaveChanges();

        return employeesEntity;
    }

    public IEnumerable<EmployeesEntity> GetEmployees()
    {
        var customer = _context.Employees.Include(x => x.RolesName).ToList();
        return _context.Employees;
    }

    public EmployeesEntity GetEmployeesById(int id)
    {
        var employeesEntity = _context.Employees.FirstOrDefault(x => x.Id == id);
        return employeesEntity ?? null!;
    }

    public EmployeesEntity UpdateEmployees(EmployeesEntity employeesEntity)
    {
        _context.Employees.Update(employeesEntity);
        _context.SaveChanges();

        return employeesEntity;
    }

    public bool DeleteEmployees(int id)
    {
        var employeesEntity = _context.Employees.FirstOrDefault(x => x.Id == id);
        if (employeesEntity != null)
        {
            _context.Employees.Remove(employeesEntity);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }

    }
}
