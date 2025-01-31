using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IOrderService
    {
        Task<bool> CreateOrderAsync(OrdersRegistrationForm form);
        Task<IEnumerable<Order>> GetAllAsync();
        Task<bool> DeleteOrderAsync(int id);
        Task<Order> UpdateOrderAsync(OrderUpdateForm form);
    }
}