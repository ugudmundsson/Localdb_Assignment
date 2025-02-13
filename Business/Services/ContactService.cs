using Business.Dtos;
using Business.Factories;
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

        var contact = ContactFactory.Create(form);
        var result = await _contactRepository.CreateAsync(contact);
        return result;
    }




    //READ-------------------------------------------------
    public async Task<IEnumerable<Contact>> GetAllAsync()
    {
        var contacts = await _contactRepository.GetAllAsync();
        return ContactFactory.Create(contacts);

    }

    public async Task<ContactEntity> GetByIdAsync(int id)
    {
        return await _contactRepository.GetAsync(x => x.Id == id);

    }




    //UPDATE-------------------------------------------------

    public async Task<Contact> UpdateContactAsync(ContactUpdateForm form)
    {
        var contact = await _contactRepository.GetAsync(x => x.Id == form.Id);

        contact = ContactFactory.UpdateEntity(contact, form);

        var result = await _contactRepository.UpdateAsync(x => x.Id == form.Id, contact);

        return ContactFactory.Create(contact);

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
