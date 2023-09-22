using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public class InterestService : IInterestService
    {
        private readonly ApplicationDbContext _context;
        public InterestService(ApplicationDbContext context)
        {
            _context = context;
            
        }
        public async Task<Interest> Add(Interest interest)
        {
            _context.Interests.Add(interest);
            _context.SaveChanges();
            return interest;
        }

        public void Delete(int id)
        {
            var data = _context.Interests.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<Interest> GetAll()
        {
            // var username = User.FindFirstValue(System.Security.Claims.ClaimTypes.Email);
           // var username = H.User.FindFirstValue(System.Security.Claims.ClaimTypes.Email);
            var data = _context.Interests.ToList();
            return data;
        }

        public Interest GetById(int id)
        {
            var data = _context.Interests.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public async Task<Interest> Update(Interest interest)
        {
            _context.Interests.Update(interest);
            _context.SaveChanges();
            return interest;
        }
    }
}
