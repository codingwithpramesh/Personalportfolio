using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
        public async Task<User> AddAsync(User user, IFormFile? file)
        {
            try
            {
               
                string wwwRootPath = _webEnvironment.WebRootPath;
                string? fileName = Path.GetFileNameWithoutExtension(file?.FileName);
                string extension = Path.GetExtension(file?.FileName);
                user.Profilepic = @"\Assets\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                string path = Path.Combine(wwwRootPath + "/Assets/", fileName);
                if (file != null)
                {


                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await file?.CopyToAsync(fileStream);
                    }
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
        public async Task<User> Update(User user, IFormFile newfile)
        {
            /*_context.Users.Update(user);
            _context.SaveChanges();
            return user;*/


            var uiserid = await _context.Users.FindAsync(user.Id);
            if (newfile != null)
            {
                
                var oldImagePath = Path.Combine(_webEnvironment.WebRootPath, user.Profilepic.TrimStart('\\'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }

               
                string fileName = Path.GetFileNameWithoutExtension(newfile.FileName);
                string extension = Path.GetExtension(newfile.FileName);
                user.Profilepic = @"\Assets\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                string path = Path.Combine(_webEnvironment.WebRootPath + "/Assets/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await newfile.CopyToAsync(fileStream);
                }
            }

            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
