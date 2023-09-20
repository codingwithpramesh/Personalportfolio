using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;

namespace Personalportfolio.Controllers
{
    [Authorize]
    public class WorkFlowController : Controller
    {
        private readonly IworkFlowService _service;

        public WorkFlowController(IworkFlowService service)
        {
            _service = service;
            
        }
        public IActionResult Index()
        {
            IEnumerable<WorkFlow> data = _service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(WorkFlow workFlow)
        {
            try
            {
                _service.Add(workFlow);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            WorkFlow data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(WorkFlow workFlow)
        {
            _service.Update(workFlow);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            WorkFlow data = _service.GetById(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            WorkFlow data = _service.GetById(id);
            return View(data);
        }
    }
}
