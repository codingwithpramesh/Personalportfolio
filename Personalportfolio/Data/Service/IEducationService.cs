using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public interface IEducationService
    {

        IEnumerable<Education> GetAll();

        Education GetById(int id);
        Task<Education> AddAsync(Education education);
        Task<Education> Update(Education education);

        void Delete(int id);
    }
}
