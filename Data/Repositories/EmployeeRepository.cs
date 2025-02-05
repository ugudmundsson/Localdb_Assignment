using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public class EmployeeRepository(DataContext context) : BaseRepository<EmployeesEntity>(context), IEmployeeRepository
{
    private readonly DataContext _context = context;

    public override async Task<IEnumerable<EmployeesEntity>> GetAllAsync()
    {
        return await _context.Employees
            .Include(o => o.Role)

            .ToListAsync();
    }
}
