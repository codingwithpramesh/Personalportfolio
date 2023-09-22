using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;
using System.Security.Claims;

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
            var usermail = User.FindFirstValue("userId");
            IEnumerable<WorkFlow> data = _service.GetAll().Where(x =>x.UId.ToString() == usermail).ToList();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkFlow workFlow)
        {

            if (ModelState.IsValid)
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
               
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (ModelState.IsValid)
            {
                WorkFlow data = _service.GetById(id);
                return View(data);
            }
            else
            {
                return View();
            }
           
        }

        [HttpPost]
        public IActionResult Edit(WorkFlow workFlow)
        {
            if (ModelState.IsValid)
            {
                _service.Update(workFlow);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }

        public async Task<IActionResult> Delete(int id)
        {
            WorkFlow data = _service.GetById(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            if (ModelState.IsValid)
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
            
        }


        public IActionResult Details(int id)
        {
            WorkFlow data = _service.GetById(id);
            return View(data);
        }
    }
}
