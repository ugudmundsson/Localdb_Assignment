using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class ProjectRepository(DataContext context) : BaseRepository<ProjectEntity>(context), IProjectRepository
{
    private readonly DataContext _context = context;


    public override async Task<IEnumerable<ProjectEntity>> GetAllAsync()
    {
        return await _context.Projects
            .Include(o => o.Employee)
            .ThenInclude(o => o.Role)
            .Include(o => o.Order)
            .Include(o => o.Customer)
            .ToListAsync();
    }
}
