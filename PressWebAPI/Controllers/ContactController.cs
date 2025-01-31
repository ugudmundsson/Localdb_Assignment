using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Mvc;



namespace PressWebAPI.Controllers;

[ApiController]
[Route("api/contact")]

public class ContactController(IContactService contactService) : ControllerBase
{

    private readonly IContactService _contactService = contactService;



    [HttpPost]
    public async Task<IActionResult> Create(ContactRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _contactService.CreateContactAsync(form);
        return Ok(result);
    }







    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _contactService.GetAllAsync();
        return Ok(result);
    }





    [HttpPut]
    public async Task<IActionResult> Update(ContactUpdateForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _contactService.UpdateContactAsync(form);
        return Ok(result);
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _contactService.DeleteContactAsync(id);
        return Ok(result);
    }


}
