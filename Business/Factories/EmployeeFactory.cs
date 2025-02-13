using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class EmployeeFactory
{
    public static EmployeesEntity Create(EmployeesRegistrationForm form)
    {
        return new EmployeesEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            RoleId = form.RoleId,
        };
    }
    public static Employee Create(EmployeesEntity entity)
    {
        return new Employee
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            RoleId = entity.RoleId,
            Role = new Role
            {
                Id = entity.Role.Id,
                RoleName = entity.Role.RoleName,
            }
        };
    }
    public static EmployeesEntity UpdateEntity(EmployeesEntity entity, EmployeeUpdateForm form)
    {
        entity.Id = form.Id;
        entity.FirstName = form.FirstName;
        entity.LastName = form.LastName;
        entity.RoleId = form.RoleId;
        return entity;
    }
    public static IEnumerable<Employee> Create(IEnumerable<EmployeesEntity> entities)
    {
        return entities.Select(x => new Employee
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            RoleId = x.RoleId,
            Role = new Role
            {
                Id = x.Role.Id,
                RoleName = x.Role.RoleName,
            }
        });
    }
}
