using DatabaseModels.DTO;
using DatabaseModels.Models;

namespace AuthenticationService.Interfaces

{
    public interface IAuthRepository
    {
        //Task<> Register (User user, string password);
        User Login(LoginDTO loginData);
        //Task<bool> UserExists(string username);
    }
}
