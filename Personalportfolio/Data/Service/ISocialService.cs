using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public interface ISocialService
    {

        IEnumerable<SocialMedia> GetAll();

        SocialMedia GetById(int id);
        Task<SocialMedia> AddAsync(SocialMedia socialMedia, IFormFile file);
        Task<SocialMedia> Update(SocialMedia socialMedia);

        void Delete(int id);
    }
}
