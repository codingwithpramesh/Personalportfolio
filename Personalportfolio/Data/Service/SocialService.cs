using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public class SocialService : ISocialService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webEnvironment;
        public SocialService(ApplicationDbContext context, IWebHostEnvironment webEnvironment)
        {
            _webEnvironment = webEnvironment;
            _context=context;

        }

        public async Task<SocialMedia> AddAsync(SocialMedia socialMedia, IFormFile file)
        {
            try
            {
                string wwwRootPath = _webEnvironment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                socialMedia.Icon = @"\Assets\Icons\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                string path = Path.Combine(wwwRootPath + "/Assets/Icons/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                await _context.AddAsync(socialMedia);
                await _context.SaveChangesAsync();
                return socialMedia;

            }catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
          
        }

        public void Delete(int id)
        {
            var data = _context.SocialMedia.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<SocialMedia> GetAll()
        {
            var data = _context.SocialMedia.ToList();
            return data;
        }

        public SocialMedia GetById(int id)
        {
            var data = _context.SocialMedia.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public async Task<SocialMedia> Update(SocialMedia socialMedia)
        {
            _context.SocialMedia.Update(socialMedia);
            _context.SaveChanges();
            return socialMedia;
        }
    }
}
