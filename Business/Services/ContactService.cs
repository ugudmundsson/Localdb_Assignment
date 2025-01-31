using Business.Dtos;
using Business.Interfaces;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;

namespace Business.Services;

public class ContactService(IContactRepository contactRepository) : IContactService
{

    private readonly IContactRepository _contactRepository = contactRepository;

    //CREATE-------------------------------------------------
    public async Task<bool> CreateContactAsync(ContactRegistrationForm form)
    {

        var contact = new ContactEntity
        {
            FirstName = form.FirstName,
            LastName = form.LastName,
            Email = form.Email,
            PhoneNumber = form.PhoneNumber,
        };

        var result = await _contactRepository.CreateAsync(contact);
        return result;
    }




    //READ-------------------------------------------------
    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        var contacts = await _contactRepository.GetAllAsync();
        return contacts.Select(x => new Contact(x.Id, x.FirstName, x.LastName, x.Email, x.PhoneNumber));
    }

    public async Task<ContactEntity> GetByIdAsync(int id)
    {
        return await _contactRepository.GetAsync(x => x.Id == id);

    }




    //UPDATE-------------------------------------------------

    public async Task<Contact> UpdateContactAsync(ContactUpdateForm form)
    {
        var contact = await _contactRepository.GetAsync(x => x.Id == form.Id);
        {
            contact.Id = form.Id;
            contact.FirstName = form.FirstName;
            contact.LastName = form.LastName;
            contact.Email = form.Email;
            contact.PhoneNumber = form.PhoneNumber;
        };

        var result = await _contactRepository.UpdateAsync(x => x.Id == form.Id, contact);
        return new Contact(result.Id, result.FirstName, result.LastName, result.Email, result.PhoneNumber);
    }





    //DELETE-------------------------------------------------

    public async Task<bool> DeleteContactAsync(int id)
    {
        var contact = await _contactRepository.GetAsync(x => x.Id == id);
        if (contact == null)
            return false;

        var result = await _contactRepository.DeleteAsync(x => x.Id == id);
        return result;
    }


}
