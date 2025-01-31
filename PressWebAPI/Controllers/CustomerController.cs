using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace PressWebAPI.Controllers;


[ApiController]
[Route("api/customer")]


public class CustomerController(ICustomerService customerService) : ControllerBase
{
   
    private readonly ICustomerService _customerService = customerService;

    [HttpPost]
    public async Task<IActionResult> Create(CustomerRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _customerService.CreateCustomerAsync(form);
        return Ok(result);
    }







    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _customerService.GetAllAsync();
        return Ok(result);
    }





    [HttpPut]
    public async Task<IActionResult> Update(CustomerUpdateForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _customerService.UpdateCustomerAsync(form);
        return Ok(result);
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _customerService.DeleteContactAsync(id);
        return Ok(result);
    }
}
