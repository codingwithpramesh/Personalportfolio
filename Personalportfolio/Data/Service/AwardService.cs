using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;
using System.Security.Claims;

namespace Personalportfolio.Data.Service
{
    public class AwardService : IAwardService
    {
        private readonly ApplicationDbContext _context;
        //private readonly IHttpContextAccessor _contextAccessor;
        public AwardService(ApplicationDbContext context/*, HttpContextAccessor contextAccessor*/)
        {
            //_contextAccessor = contextAccessor;
            _context=context;

        }
        public void Add(Awards awards)
        {
            _context.Awards.Add(awards);
            _context.SaveChanges();
           
        }

        public void Delete(int id)
        {
            var data = _context.Awards.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }


        public IEnumerable<Awards> GetAll()
        {
            
            var data = _context.Awards.ToList();
            return data;
        }

        public Awards GetById(int id)
        {
          
            var data = _context.Awards.Where(x => x.Id == id).FirstOrDefault();
           // string test = _contextAccessor.HttpContext.User.FindFirstValue("userId");
            return data;
        }

        public async Task<Awards> Update(Awards awards)
        {
            _context.Awards.Update(awards);
            _context.SaveChanges();
            return awards;
        }
    }
}
