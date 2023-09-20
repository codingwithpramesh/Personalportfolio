using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;

namespace Personalportfolio.Controllers
{
    [Authorize]
    public class ToolsController : Controller
    {
        private readonly IToolsService _service;
        public ToolsController(IToolsService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            IEnumerable<Tools> data = _service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Tools tools, IFormFile file)
        {
            try
            {
               await _service.AddAsync(tools, file);
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
            Tools data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Tools tools)
        {
            _service.Update(tools);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Tools data = _service.GetById(id);
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
            Tools data = _service.GetById(id);
            return View(data);
        }
    }
}
