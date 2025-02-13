using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class OrderFactory
{
    public static OrderEntity Update(OrderEntity entity, OrderUpdateForm form)
    {
        entity.Id = form.Id;
        entity.OrderName = form.OrderName;
        entity.Price = form.Price;
        return entity;
    }
    public static Order Create(OrderEntity entity)
    {
        return new Order
        {
            Id = entity.Id,
            OrderName = entity.OrderName,
            Price = entity.Price
        };
    }
    public static OrderEntity Create(OrdersRegistrationForm Regform)
    {
        return new OrderEntity
        {
            OrderName = Regform.OrderName,
            Price = Regform.Price
        };
    }
    public static IEnumerable<Order> Create(IEnumerable<OrderEntity> entities)
    {
        return entities.Select(Create);
    }
}
