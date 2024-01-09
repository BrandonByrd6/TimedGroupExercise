
using TGE.Models.User;

namespace TGE.Services.User;

public interface IUserService
{
    Task<bool> RegisterUserAsync(UserRegister model);
    Task<UserDetail?> GetUserByIdAsync(int userId);

}