﻿using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;



namespace Data.Repositories;

public class CustomerRepository(DataContext context) : BaseRepository<CustomerEntity>(context), ICustomertRepository
{
    private readonly DataContext _context = context;

    public override async Task<IEnumerable<CustomerEntity>> GetAllAsync()
    {
        return await _context.Customer
            .Include(o => o.Contact)

            .ToListAsync();
    }
}
