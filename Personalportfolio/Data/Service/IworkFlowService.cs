using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public interface IworkFlowService
    {

        IEnumerable<WorkFlow> GetAll();

        WorkFlow GetById(int id);
        Task<WorkFlow> Add(WorkFlow workFlow);
        Task<WorkFlow> Update(WorkFlow workFlow);

        void Delete(int id);
    }
}
