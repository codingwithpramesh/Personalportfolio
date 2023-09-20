using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;
using System.Numerics;

namespace Personalportfolio.Data.Service
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webEnvironment;

        public UserService(ApplicationDbContext context,  IWebHostEnvironment webEnvironment)
        {
          
            _context = context;
            _webEnvironment=webEnvironment;

        }
        public async Task<User> AddAsync(User user, IFormFile file)
        {
            try
            {
                string wwwRootPath = _webEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                user.Profilepic = @"\Assets\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                string path = Path.Combine(wwwRootPath + "/Assets/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
           
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public void Delete(int id)
        {
            var data = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<User> GetAll()
        {
            var data = _context.Users.ToList();
            return data;
        }

        public User GetById(int id)
        {
            var data = _context.Users.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }
/*
        public Task<Status> Login(LoginVm vm)
        {
            throw new NotImplementedException();
        }

        public Task LogoutAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Status> Register(Register vm)
        {
            throw new NotImplementedException();
        }
*/
        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
            return user;
        }
    }
}
