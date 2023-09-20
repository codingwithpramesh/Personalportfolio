using Microsoft.EntityFrameworkCore;
using Personalportfolio.Models;

namespace Personalportfolio.Data.Service
{
    public class WorkflowService : IworkFlowService
    {
        private readonly ApplicationDbContext _context;
        public WorkflowService(ApplicationDbContext context)
        {

            _context=context;

        }

        public async Task<WorkFlow> Add(WorkFlow workFlow)
        {
            _context.WorkFlows.Add(workFlow);
            _context.SaveChanges();
            return workFlow;
        }

        public void Delete(int id)
        {
            var data = _context.WorkFlows.Where(x => x.Id == id).FirstOrDefault();
            _context.Remove(data);
            _context.SaveChanges();
        }

        public IEnumerable<WorkFlow> GetAll()
        {
            var data = _context.WorkFlows.ToList();
            return data;
        }

        public WorkFlow GetById(int id)
        {
            var data = _context.WorkFlows.Where(x => x.Id == id).FirstOrDefault();
            return data;
        }

        public async Task<WorkFlow> Update(WorkFlow workFlow)
        {
            _context.WorkFlows.Update(workFlow);
            _context.SaveChanges();
            return workFlow;
        }
    }
}
