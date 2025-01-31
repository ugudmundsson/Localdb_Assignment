using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace PressWebAPI.Controllers;

[ApiController]
[Route("api/order")]

public class OrderController(IOrderService orderService) : ControllerBase
{
    private readonly IOrderService _orderService = orderService;

    [HttpPost]
    public async Task<IActionResult> Create(OrdersRegistrationForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _orderService.CreateOrderAsync(form);
        return Ok(result);
    }







    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var result = await _orderService.GetAllAsync();
        return Ok(result);
    }





    [HttpPut]
    public async Task<IActionResult> Update(OrderUpdateForm form)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _orderService.UpdateOrderAsync(form);
        return Ok(result);
    }





    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _orderService.DeleteOrderAsync(id);
        return Ok(result);
    }

}
