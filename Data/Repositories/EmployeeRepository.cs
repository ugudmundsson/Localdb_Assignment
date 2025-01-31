using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories;

public class EmployeeRepository(DataContext context) : BaseRepository<EmployeesEntity>(context), IEmployeeRepository
{
    private readonly DataContext _context = context;
}
