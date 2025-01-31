using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IRoleService
    {
        Task<bool> CreateRoleAsync(RoleRegistrationForm form);
        Task<IEnumerable<Role>> GetAllAsync();
        Task<bool> DeleteRoleAsync(int id);
        Task<Role> UpdateRoleAsync(RoleUpdateForm form);
    }
}