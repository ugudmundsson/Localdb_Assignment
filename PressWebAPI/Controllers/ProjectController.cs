using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace PressWebAPI.Controllers;

[ApiController]
[Route("api/project")]

public class ProjectController(IProjectService projectService) : ControllerBase
{
    
    private readonly IProjectService _projectService = projectService;
    
    
    
    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _projectService.CreateProjectAsync(form);
        return Ok(result);
    }







    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _projectService.GetAllAsync();
        return Ok(result);
    }





    [HttpPut]
    public async Task<IActionResult> Update(ProjectUpdateForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _projectService.UpdateProjectAsync(form);
        return Ok(result);
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _projectService.DeleteProjectAsync(id);
        return Ok(result);
    }

}
