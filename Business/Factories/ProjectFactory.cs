using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ProjectFactory
{
    public static ProjectEntity Create(ProjectRegistrationForm form)
    {
        return new ProjectEntity
        {
            ProjectName = form.ProjectName,
            ProjectDescription = form.ProjectDescription,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
            CustomerId = form.CustomerId,
            EmployeeId = form.EmployeeId,
            OrderId = form.OrderId,
            StatusId = form.StatusId
        };
    }
    public static Project Create(ProjectEntity entity)
    {
        return new Project
        {
            Id = entity.Id,
            ProjectName = entity.ProjectName,
            Description = entity.ProjectDescription,
            Startdate = entity.StartDate,
            Enddate = entity.EndDate,
            CustomerId = entity.CustomerId,
            EmployeeId = entity.EmployeeId,
            OrderId = entity.OrderId,
            StatusId = entity.StatusId
        };
    }
    public static ProjectEntity UpdateEntity(ProjectEntity entity, ProjectUpdateForm form)
    {
        entity.Id = form.Id;
        entity.ProjectName = form.ProjectName;
        entity.ProjectDescription = form.Description;
        entity.StartDate = form.StartDate;
        entity.EndDate = form.EndDate;
        entity.CustomerId = form.CustomerId;
        entity.EmployeeId = form.EmployeeId;
        entity.OrderId = form.OrderId;
        entity.StatusId = form.StatusId;
        return entity;
    }
    public static IEnumerable<Project> Create(IEnumerable<ProjectEntity> entities)
    {
        return entities.Select(x => new Project
        {
            Id = x.Id,
            ProjectName = x.ProjectName,
            Description = x.ProjectDescription,
            Startdate = x.StartDate,
            Enddate = x.EndDate,
            CustomerId = x.CustomerId,
            Customer = new Customer
            {
                Id = x.Customer.Id,
                Name = x.Customer.Name,
                ContactId = x.Customer.ContactId,
                Contact = new Contact
                {
                    Id = x.Customer.Contact.Id,
                    FirstName = x.Customer.Contact.FirstName,
                    LastName = x.Customer.Contact.LastName,
                    Email = x.Customer.Contact.Email,
                    PhoneNumber = x.Customer.Contact.PhoneNumber
                }
            },
            Employee = new Employee
            {
                Id = x.Employee.Id,
                FirstName = x.Employee.FirstName,
                LastName = x.Employee.LastName,
                RoleId = x.Employee.RoleId,
                Role = new Role
                {
                    Id = x.Employee.Role.Id,
                    RoleName = x.Employee.Role.RoleName
                }
            },
            Order = new Order
            {
                Id = x.Order.Id,
                OrderName = x.Order.OrderName,
                Price = x.Order.Price,
            },
            Status = new Status
            {
                Id = x.Status.Id,
                Name = x.Status.Name

            }
        });

    }
    }
