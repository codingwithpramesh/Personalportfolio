using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;
using System.Security.Claims;

namespace Personalportfolio.Data.Service
{
    public class EducationService : IEducationService
    {
        private readonly ApplicationDbContext _context;
       // private readonly HttpContextAccessor _httpcontext;
        public EducationService( ApplicationDbContext context)
        {
            /*_httpcontext = httpcontext;*/
            _context=context;

        }

        public async  Task<Education> AddAsync(Education education)
        {
         
          await  _context.Educations.AddAsync(education);
          await  _context.SaveChangesAsync();
            return education;
            
        }

        public void Delete(int id)
        {
            var data = _context.Educations.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Education> GetAll()
        {
          //  var userId = _httpcontext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var data = _context.Educations/*Where(x=>x.user.Email == userId)*/.ToList();
            return data;
        }

        public Education GetById(int id)
        {
            var data = _context.Educations.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public async Task<Education> Update(Education education)
        {
            _context.Educations.Update(education);
            _context.SaveChanges();
            return education;
        }
    }
}
