using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;

namespace Personalportfolio.Controllers
{
    [Authorize]
    public class AwardController : Controller
    {
        private readonly IAwardService _service;
        public AwardController( IAwardService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            IEnumerable<Awards> data = _service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Awards awards)
        {
            try
            {
                _service.Add(awards);
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
            Awards data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Awards awards)
        {
            _service.Update(awards);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Awards data = _service.GetById(id);
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
            Awards data = _service.GetById(id);
            return View(data);
        }
    }
}
