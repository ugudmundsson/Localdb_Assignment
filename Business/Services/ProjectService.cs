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
        return contacts.Select(x => new Project(x.Id, x.ProjectName, x.ProjectDescription, x.Status, x.StartDate, x.EndDate, x.OrderId, x.CustomerId, x.EmployeeId));
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
            return new Project(result.Id, result.ProjectName, result.ProjectDescription, result.Status, result.StartDate, result.EndDate, result.CustomerId, result.OrderId, result.EmployeeId);
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
