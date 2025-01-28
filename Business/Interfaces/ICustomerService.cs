using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        CustomerEntity CreateCustomer(CustomerEntity customerEntity);
        bool DeleteCustomer(int id);
        IEnumerable<CustomerEntity> GetCustomer();
        CustomerEntity GetCustomerById(int id);
        CustomerEntity UpdateCustomer(CustomerEntity customerEntity);
    }
}