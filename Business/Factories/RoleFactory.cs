using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Factories;

public class RoleFactory
{
    public static RoleEntity Update(RoleEntity entity, RoleUpdateForm form)
    {
        entity.Id = form.Id;
        entity.RoleName = form.RoleName;
        return entity;
    }
    public static Role Create(RoleEntity entity)
    {
        return new Role
        {
            Id = entity.Id,
            RoleName = entity.RoleName
        };
    }
    public static RoleEntity Create(RoleRegistrationForm Regform)
    {
        return new RoleEntity
        {
            RoleName = Regform.RoleName
        };
    }
    public static IEnumerable<Role> Create(IEnumerable<RoleEntity> entities)
    {
        return entities.Select(Create);
    }
}
