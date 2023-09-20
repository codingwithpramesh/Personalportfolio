using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public interface IAwardService
    {
        IEnumerable<Awards> GetAll();

        Awards GetById(int id);
        void Add(Awards awards);
        Task<Awards> Update(Awards awards);

        void Delete(int id);
    }
}
