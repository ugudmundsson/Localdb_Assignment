
using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;


namespace Business.Services;

public class CustomerService(ICustomertRepository customerRepository) : ICustomerService
{
    private readonly ICustomertRepository _customerRepository = customerRepository;


    //CREATE-------------------------------------------------
    public async Task<bool> CreateCustomerAsync(CustomerRegistrationForm form)
    {
       
       

        var customer = new CustomerEntity
        {
            Name = form.Name,
            ContactId = form.ContactId,
        };

        var result = await _customerRepository.CreateAsync(customer);
        return result;
    }


    //READ-------------------------------------------------
    public async Task<IEnumerable<Customer>> GetAllAsync()
    {
        var customers = await _customerRepository.GetAllAsync();
        return customers.Select(x => new Customer(x.Id, x.Name, x.ContactId));
    }




    //UPDATE-------------------------------------------------

    public async Task<Customer> UpdateCustomerAsync(CustomerUpdateForm form)
    {
        var customer = await _customerRepository.GetAsync(x => x.Id == form.Id);
        {
            customer.Id = form.Id;
            customer.Name = form.Name;
            customer.ContactId = form.ContactId;
            var result = await _customerRepository.UpdateAsync(x => x.Id == form.Id, customer);
            return new Customer(result.Id, result.Name, result.ContactId);
        }
    }



    //DELETE-------------------------------------------------

    public async Task<bool> DeleteContactAsync(int id)
    {
        var contact = await _customerRepository.GetAsync(x => x.Id == id);
        if (contact == null)
            return false;

        var result = await _customerRepository.DeleteAsync(x => x.Id == id);
        return result;
    }



}