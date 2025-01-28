using Business.Dtos;
using Business.Interfaces;
using Data.Contexts;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Business.Services;

public class CustomerService(DataContext context) : ICustomerService
{

    private readonly DataContext _context = context;


    public CustomerEntity CreateCustomer(CustomerEntity customerEntity)
    {
   
        _context.Customer.Add(customerEntity);
        _context.SaveChanges();

        return customerEntity;
    }

    public IEnumerable<CustomerEntity> GetCustomer()
    {
        var customer = _context.Customer.Include(x => x.Contact).ToList();
        return _context.Customer;
    }

    public CustomerEntity GetCustomerById(int id)
    {
        var customerEntity = _context.Customer.FirstOrDefault(x => x.Id == id);
        return customerEntity ?? null!;
    }

    public CustomerEntity UpdateCustomer(CustomerEntity customerEntity)
    {
        _context.Customer.Update(customerEntity);
        _context.SaveChanges();

        return customerEntity;
    }

    public bool DeleteCustomer(int id)
    {
        var customerEntity = _context.Customer.FirstOrDefault(x => x.Id == id);
        if (customerEntity != null)
        {
            _context.Customer.Remove(customerEntity);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }

    }
}
