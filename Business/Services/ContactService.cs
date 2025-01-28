using Business.Interfaces;
using Data.Contexts;
using Data.Entities;

namespace Business.Services;

public class ContactService(DataContext context) : IContactService
{

    private readonly DataContext _context = context;



    // Create contact


    public ContactEntity CreateContact(ContactEntity contactEntity)
    {

        _context.Contacts.Add(contactEntity);
        _context.SaveChanges();

        return contactEntity;
    }

    public IEnumerable<ContactEntity> GetContacts()
    {
        return _context.Contacts;
    }



    // Get contact by id


    public ContactEntity GetContactById(int id)
    {
        var contactEntity = _context.Contacts.FirstOrDefault(x => x.Id == id);
        return contactEntity ?? null!;
    }

    public ContactEntity GetContactByEmail(string email)
    {
        var contactEntity = _context.Contacts.FirstOrDefault(x => x.Email == email);
        return contactEntity ?? null!;
    }


    // Update contact



    public ContactEntity UpdateContact(ContactEntity contactEntity)
    {
        _context.Contacts.Update(contactEntity);
        _context.SaveChanges();

        return contactEntity;
    }



    // Delete contact


    public bool DeleteContact(int id)
    {
        var contactEntity = _context.Contacts.FirstOrDefault(x => x.Id == id);
        if (contactEntity != null)
        {
            _context.Contacts.Remove(contactEntity);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }

    }
}
