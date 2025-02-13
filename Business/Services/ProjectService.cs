using Business.Dtos;
using Data.Interfaces;
using Data.Entities;
using Business.Models;
using Data.Repositories;
using Business.Interfaces;
using Business.Factories;
namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;


    //CREATE-------------------------------------------------
    public async Task<bool> CreateProjectAsync(ProjectRegistrationForm form)
    {
        var project = ProjectFactory.Create(form);

        var result = await _projectRepository.CreateAsync(project);

        return result;
    }


    //READ-------------------------------------------------
    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        var projects = await _projectRepository.GetAllAsync();

        return ProjectFactory.Create(projects);
    }



    //UPDATE-------------------------------------------------

    public async Task<Project> UpdateProjectAsync(ProjectUpdateForm form)
    {
        var project = await _projectRepository.GetAsync(x => x.Id == form.Id);

        project = ProjectFactory.UpdateEntity(project, form);

        var result = await _projectRepository.UpdateAsync(x => x.Id == form.Id, project);
            
        return ProjectFactory.Create(project);
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
