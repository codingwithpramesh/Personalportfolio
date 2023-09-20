using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public class ToolService : IToolsService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;
        public ToolService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment=environment;

        }

        public async Task<Tools> AddAsync(Tools tools, IFormFile file)
        {

            try
            {
                string wwwRootPath = _environment.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(file.FileName);
                string extension = Path.GetExtension(file.FileName);
                tools.Icon = @"\Assets\Icons\" + (fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension);
                string path = Path.Combine(wwwRootPath + "/Assets/Icons/", fileName);
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }

                await _context.AddAsync(tools);
                await _context.SaveChangesAsync();
                return tools;

            }catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
            
        }

        public void Delete(int id)
        {
            var data = _context.Tools.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Tools> GetAll()
        {
            var data = _context.Tools.ToList();
            return data;
        }

        public Tools GetById(int id)
        {
            var data = _context.Tools.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public async Task<Tools> Update(Tools tools)
        {
            _context.Tools.Update(tools);
            _context.SaveChanges();
            return tools;
        }
    }
}
