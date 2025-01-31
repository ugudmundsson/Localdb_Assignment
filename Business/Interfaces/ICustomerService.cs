using Business.Dtos;
using Business.Models;

namespace Business.Interfaces
{
    public interface ICustomerService
    {
        Task<bool>CreateCustomerAsync(CustomerRegistrationForm form);
        Task<IEnumerable<Customer>> GetAllAsync();
        Task<Customer> UpdateCustomerAsync(CustomerUpdateForm form);
        Task<bool> DeleteContactAsync(int id);
    }
}