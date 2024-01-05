using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using TGE.Data;
using TGE.Data.Entities;
using TGE.Models.User;

namespace TGE.Services.User
{
    public class NewUserService : INewUserService
    {
         private readonly ApplicationDbContext _context;
    private readonly UserManager<UserEntity> _userManager;
    private readonly SignInManager<UserEntity> _signInManager;

    public NewUserService(ApplicationDbContext context, UserManager<UserEntity> userManager, SignInManager<UserEntity> signInManager)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public async Task<bool> RegisterUserAsync(UserRegister model)
    {

        if(await CheckEmailAvaliblitiy(model.Email) == false) {
            return false;
        }

        UserEntity entity = new() {
            Email = model.Email
        };
        IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

        return registerResult.Succeeded;
    }
    
    private async Task<bool> CheckEmailAvaliblitiy(string email) {
        UserEntity? existingUser =  await _userManager.FindByEmailAsync(email);
        return existingUser is null;
    }

    }
}