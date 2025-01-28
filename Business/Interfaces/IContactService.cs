﻿using Data.Entities;

namespace Business.Interfaces
{
    public interface IContactService
    {
        ContactEntity CreateContact(ContactEntity contactEntity);
        bool DeleteContact(int id);
        ContactEntity GetContactByEmail(string email);
        ContactEntity GetContactById(int id);
        IEnumerable<ContactEntity> GetContacts();
        ContactEntity UpdateContact(ContactEntity contactEntity);
    }
}