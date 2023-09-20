using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public interface IToolsService
    {

        IEnumerable<Tools> GetAll();

        Tools GetById(int id);
        Task<Tools> AddAsync(Tools tools, IFormFile file);
        Task<Tools> Update(Tools tools);

        void Delete(int id);
    }
}
