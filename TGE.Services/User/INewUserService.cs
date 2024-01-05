using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TGE.Models.User;

namespace TGE.Services.User
{
    public interface INewUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
    }
}