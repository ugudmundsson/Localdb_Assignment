using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class OrderService(IOrderRepository orderRepository) : IOrderService
{
    private readonly IOrderRepository _orderRepository = orderRepository;


    //CREATE-------------------------------------------------
    public async Task<bool> CreateOrderAsync(OrdersRegistrationForm form)
    {

        var order = new OrderEntity
        {
            OrderName = form.OrderName,
            Price = form.Price,
        };

        var result = await _orderRepository.CreateAsync(order);
        return result;
    }

    //READ-------------------------------------------------

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return orders.Select(x => new Order(x.Id, x.OrderName, x.Price));
    }




    //UPDATE-------------------------------------------------

    public async Task<Order> UpdateOrderAsync(OrderUpdateForm form)
    {
        var order = await _orderRepository.GetAsync(x => x.Id == form.Id);
        {
            order.Id = form.Id;
            order.OrderName = form.OrderName;
            order.Price = form.Price;

            var result = await _orderRepository.UpdateAsync(x => x.Id == form.Id, order);
            return new Order(result.Id, result.OrderName, result.Price);
        }
    }


    //DELETE-------------------------------------------------

    public async Task<bool> DeleteOrderAsync(int id)
    {
        var contact = await _orderRepository.GetAsync(x => x.Id == id);
        if (contact == null)
            return false;

        var result = await _orderRepository.DeleteAsync(x => x.Id == id);
        return result;
    }


}
