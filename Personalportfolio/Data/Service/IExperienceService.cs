using Personalportfolio.Models;
using System.Numerics;

namespace Personalportfolio.Data.Service
{
    public interface IExperienceService
    {

        IEnumerable<Experience> GetAll();

        Experience GetById(int id);
        Task<Experience> Add(Experience experience);
        Task<Experience> Update(Experience experience);

        void Delete(int id);
    }
}
