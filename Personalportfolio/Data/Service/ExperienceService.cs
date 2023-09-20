using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{

   
    public class ExperienceService : IExperienceService
    {
        private readonly ApplicationDbContext _context;
        public ExperienceService( ApplicationDbContext context)
        {

            _context=context;

        }
        public async Task<Experience> Add(Experience experience)
        {
            _context.Experiences.Add(experience);
            _context.SaveChanges();
            return experience;
        }

        public void Delete(int id)
        {
            var data = _context.Experiences.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Experience> GetAll()
        {
            var data = _context.Experiences.ToList();
            return data;
        }

        public Experience GetById(int id)
        {
            var data = _context.Experiences.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public async Task<Experience> Update(Experience experience)
        {
            _context.Experiences.Update(experience);
            _context.SaveChanges();
            return experience;
        }
    }
}
