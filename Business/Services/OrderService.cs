using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Business.Factories;
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
        await _orderRepository.BeginTransactionAsync();
        try
        {
        var order = OrderFactory.Create(form);
            await _orderRepository.CommitTransactionAsync();
            await _orderRepository.SaveChangesAsync();
            var result = await _orderRepository.CreateAsync(order);
        return result;

        }
        catch
        {
            await _orderRepository.RollbackTransactionAsync();
            return false;
        }

    }

    //READ-------------------------------------------------

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        var orders = await _orderRepository.GetAllAsync();
        return OrderFactory.Create(orders);
    }




    //UPDATE-------------------------------------------------

    public async Task<Order> UpdateOrderAsync(OrderUpdateForm form)
    {
        await _orderRepository.BeginTransactionAsync();
        try
        {
        var order = await _orderRepository.GetAsync(x => x.Id == form.Id);

        order = OrderFactory.Update(order, form);
            await _orderRepository.CommitTransactionAsync();
            await _orderRepository.SaveChangesAsync();
            var result = await _orderRepository.UpdateAsync(x => x.Id == form.Id, order);
            
        return OrderFactory.Create(order);

        }
        catch
        {
            await _orderRepository.RollbackTransactionAsync();
            return null;
        }
    }


    //DELETE-------------------------------------------------

    public async Task<bool> DeleteOrderAsync(int id)
    {
        await _orderRepository.BeginTransactionAsync();
        try
        {
        var contact = await _orderRepository.GetAsync(x => x.Id == id);
        if (contact == null)
            return false;
            var result = await _orderRepository.DeleteAsync(x => x.Id == id);
            await _orderRepository.CommitTransactionAsync();
            await _orderRepository.SaveChangesAsync();
            return result;

        }
        catch
        {
            await _orderRepository.RollbackTransactionAsync();
            return false;
        }
    }


}
