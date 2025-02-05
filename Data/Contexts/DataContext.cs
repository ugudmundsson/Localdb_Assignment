using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ProjectEntity> Projects { get; set; }

    public DbSet<ContactEntity> Contacts { get; set; }

    public DbSet<CustomerEntity> Customer { get; set; }

    public DbSet<EmployeesEntity> Employees { get; set; }

    public DbSet<OrderEntity> Orders { get; set; }

    public DbSet<RoleEntity> Roles { get; set; }

   
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerEntity>()
            .HasOne(c => c.Contact)
            .WithMany(c => c.Customer)
            .HasForeignKey(c => c.ContactId);

        modelBuilder.Entity<EmployeesEntity>()
            .HasOne(c => c.Role);


        modelBuilder.Entity<ProjectEntity>();
            

            
    }

}
