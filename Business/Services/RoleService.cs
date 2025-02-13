﻿using Business.Dtos;
using Business.Interfaces;
using Business.Factories;
using Business.Models;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Services;

public class RoleService(IRoleRepository roleRepository) : IRoleService
{
    private readonly IRoleRepository _roleRepository = roleRepository;




    //CREATE-------------------------------------------------
    public async Task<bool> CreateRoleAsync(RoleRegistrationForm form)
    {
        var role = RoleFactory.Create(form);
        var result = await _roleRepository.CreateAsync(role);
        return result;
    }



    //READ-------------------------------------------------
    public async Task<IEnumerable<Role>> GetAllAsync()
    {
       var roles = await _roleRepository.GetAllAsync();
        return RoleFactory.Create(roles);
    }





    //UPDATE-------------------------------------------------

    public async Task<Role> UpdateRoleAsync(RoleUpdateForm form)
    {
        var role = await _roleRepository.GetAsync(x => x.Id == form.Id);

        role = RoleFactory.Update(role, form);

        var result = await _roleRepository.UpdateAsync(x => x.Id == form.Id, role);

        return RoleFactory.Create(role);

    }






    //DELETE-------------------------------------------------

    public async Task<bool> DeleteRoleAsync(int id)
    {
        var contact = await _roleRepository.GetAsync(x => x.Id == id);
        if (contact == null)
            return false;

        var result = await _roleRepository.DeleteAsync(x => x.Id == id);
        return result;
    }




}
