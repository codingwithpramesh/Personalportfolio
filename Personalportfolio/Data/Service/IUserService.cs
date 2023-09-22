using Microsoft.Win32;
using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public interface IUserService
    {
        IEnumerable<User> GetAll();

        User GetById(int id);
        Task<User> AddAsync(User user, IFormFile file);
        Task<User> Update(User user, IFormFile newFile);

        void Delete(int id);


       /* Task<Status> Login(LoginVm vm);

        Task<Status> Register(Register vm);

        Task LogoutAsync();*/

    }
}
