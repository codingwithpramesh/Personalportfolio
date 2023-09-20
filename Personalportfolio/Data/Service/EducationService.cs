using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public class EducationService : IEducationService
    {
        private readonly ApplicationDbContext _context;
        public EducationService( ApplicationDbContext context)
        {

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
            var data = _context.Educations.ToList();
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
