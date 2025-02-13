using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace PressWebAPI.Controllers;


[ApiController]
[Route("api/employee")]

public class EmployeeController(IEmployeesService employeesService) : ControllerBase
{
 
    private readonly IEmployeesService _employeeService = employeesService;



    [HttpPost]
    public async Task<IActionResult> Create(EmployeesRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _employeeService.CreateEmployeesAsync(form);
        return Ok(result);
    }







    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _employeeService.GetEmployeesAsync();
        return Ok(result);
    }





    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, EmployeeUpdateForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _employeeService.UpdateEmployeesAsync(form);
        return Ok(result);
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _employeeService.DeleteEmployeesAsync(id);
        return Ok(result);
    }
}
