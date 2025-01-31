using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace PressWebAPI.Controllers;

[ApiController]
[Route("api/role")]

public class RoleController(IRoleService roleService) : ControllerBase  
{
    private readonly IRoleService _roleService = roleService;



    [HttpPost]
    public async Task<IActionResult> Create(RoleRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _roleService.CreateRoleAsync(form);
        return Ok(result);
    }
   



    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _roleService.GetAllAsync();
        return Ok(result);
    }
    
    
    
    
    
    [HttpPut]

    public async Task<IActionResult> Update(RoleUpdateForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _roleService.UpdateRoleAsync(form);
        return Ok(result);
    }




    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _roleService.DeleteRoleAsync(id);
        return Ok(result);
    }

}
