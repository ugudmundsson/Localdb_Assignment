using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class ContactFactory
{
    public static ContactEntity UpdateEntity(ContactEntity entity, ContactUpdateForm form)
    {
        entity.Id = form.Id;
        entity.FirstName = form.FirstName;
        entity.LastName = form.LastName;
        entity.Email = form.Email;
        entity.PhoneNumber = form.PhoneNumber;
        return entity;

    }
    public static Contact Create(ContactEntity entity)
    {
        return new Contact
        {
            Id = entity.Id,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            Email = entity.Email,
            PhoneNumber = entity.PhoneNumber
        };
    }
    public static ContactEntity Create(ContactRegistrationForm Regform)
    {
        return new ContactEntity
        {
            FirstName = Regform.FirstName,
            LastName = Regform.LastName,
            Email = Regform.Email,
            PhoneNumber = Regform.PhoneNumber
        };         
    }
    public static IEnumerable<Contact> Create(IEnumerable<ContactEntity> entities)
    {
        return entities.Select(Create);
    }

}
