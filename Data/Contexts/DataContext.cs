﻿using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<ProjectEntity> Projects { get; set; }

    public DbSet<ContactEntity> Contacts { get; set; }

    public DbSet<CustomerEntity> Customer { get; set; }

    public DbSet<EmployeesEntity> Employees { get; set; }

    public DbSet<OrderEntity> Orders { get; set; }

    public DbSet<RoleEntity> Roles { get; set; }

    public DbSet<StatusEntity> Status { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProjectEntity>()
            .HasOne(c => c.Status);

        modelBuilder.Entity<StatusEntity>().HasData(
            new StatusEntity { Id = 1, Name = "Pending"},
            new StatusEntity { Id = 2, Name = "Active"},
            new StatusEntity { Id = 3, Name = "Completed" });

        modelBuilder.Entity<CustomerEntity>()
            .HasOne(c => c.Contact)
            .WithMany(c => c.Customer)
            .HasForeignKey(c => c.ContactId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<EmployeesEntity>()
            .HasOne(c => c.Role)
            .WithMany(c => c.Employees)
            .HasForeignKey(c => c.RoleId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(c => c.Employee)
            .WithMany(c => c.Projects)
            .HasForeignKey(c => c.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProjectEntity>()
            .HasOne(c => c.Customer)
            .WithMany(c => c.Projects)
            .HasForeignKey(c => c.CustomerId)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<ProjectEntity>()
            .HasOne(c => c.Order)
            .WithMany(c => c.Projects)
            .HasForeignKey(c => c.OrderId)
            .OnDelete(DeleteBehavior.Restrict);


           
    }

}
