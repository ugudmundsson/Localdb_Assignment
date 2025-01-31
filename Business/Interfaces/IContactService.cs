using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IContactService
    {
        Task<bool> CreateContactAsync(ContactRegistrationForm form);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<ContactEntity> GetByIdAsync(int id);
        Task<Contact> UpdateContactAsync(ContactUpdateForm form);
        Task<bool> DeleteContactAsync(int id);
    }
}