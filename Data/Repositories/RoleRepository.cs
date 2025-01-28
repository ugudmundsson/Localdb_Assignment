using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class RoleRepository(DataContext context) : BaseRepository<RolesEntity>(context), IRoleRepository
{
    private readonly DataContext _context = context;
}
