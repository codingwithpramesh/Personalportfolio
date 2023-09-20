using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public interface IInterestService
    {
        IEnumerable<Interest> GetAll();

        Interest GetById(int id);
        Task<Interest> Add(Interest interest);
        Task<Interest> Update(Interest interest);

        void Delete(int id);
    }
}
