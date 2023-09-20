using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;

namespace Personalportfolio.Controllers
{
    [Authorize]
    public class EducationController : Controller
    {
        private readonly IEducationService _service;
        public EducationController(IEducationService service)
        {
            _service = service;  
        }
        public IActionResult Index()
        {
            IEnumerable<Education> data = _service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public  IActionResult Create(Education education)
        {
            try
            {
                _service.AddAsync(education);
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
            Education data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Education education)
        {
            _service.Update(education);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Education data = _service.GetById(id);
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
            Education data = _service.GetById(id);
            return View(data);
        }
    }
}
