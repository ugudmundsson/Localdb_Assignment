using Business.Dtos;
using Data.Interfaces;
using Data.Entities;
using Business.Models;
using Data.Repositories;
using Business.Interfaces;
namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;


    //CREATE-------------------------------------------------
    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        var project = new ProjectEntity
        {
            ProjectName = form.ProjectName,
            ProjectDescription = form.ProjectDescription,
            StartDate = form.StartDate,
            EndDate = form.EndDate,
            Status = form.Status,
            CustomerId = form.CustomerId,
            OrderId = form.OrderId,
            EmployeeId = form.EmployeeId
        };
        var result = await _projectRepository.CreateAsync(project);
        return result;
    }


    //READ-------------------------------------------------
    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        var contacts = await _projectRepository.GetAllAsync();
        return contacts.Select(x => new Project
        {
            Id = x.Id,
            ProjectName = x.ProjectName,
            Description = x.ProjectDescription,
            Status = x.Status,
            Startdate = x.StartDate,
            Enddate = x.EndDate,
            EmployeeId = x.EmployeeId,
            CustomerId = x.CustomerId,
            OrderId = x.OrderId,    
            Employee = new Employee
            {
                Id = x.Employee.Id,
                FirstName = x.Employee.FirstName,
                LastName = x.Employee.LastName,
                Role = new Role
                {
                    Id = x.Employee.Role.Id,
                    RoleName = x.Employee.Role.RoleName,
                }
            },
            Customer = new Customer
            {
                Id = x.Customer.Id,
                Name = x.Customer.Name,
            },
            Order = new Order
            {
                Id = x.Order.Id,
                OrderName = x.Order.OrderName,
                Price = x.Order.Price
            }
        });
    }



    //UPDATE-------------------------------------------------

    public async Task<Project> UpdateProjectAsync(ProjectUpdateForm form)
    {
        var project = await _projectRepository.GetAsync(x => x.Id == form.Id);
        {
            project.Id = form.Id;
            project.ProjectName = form.ProjectName;
            project.ProjectDescription = form.Description;
            project.StartDate = form.StartDate;
            project.EndDate = form.EndDate;
            project.Status = form.Status;
            project.CustomerId = form.CustomerId;
            project.OrderId = form.OrderId;
            project.EmployeeId = form.EmployeeId;


            var result = await _projectRepository.UpdateAsync(x => x.Id == form.Id, project);
            return new Project
            {
                Id = form.Id,
                ProjectName = form.ProjectName,
                Description = form.Description,
                Status = form.Status,
                Startdate = form.StartDate,
                Enddate = form.EndDate,
                CustomerId= form.CustomerId,
                OrderId = form.OrderId,
                EmployeeId= form.EmployeeId,
            };
        }
    }

    //DELETE-------------------------------------------------

    public async Task<bool> DeleteProjectAsync(int id)
    {
        var contact = await _projectRepository.GetAsync(x => x.Id == id);
        if (contact == null)
            return false;

        var result = await _projectRepository.DeleteAsync(x => x.Id == id);
        return result;
    }


}
