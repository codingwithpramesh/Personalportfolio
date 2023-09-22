using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;

namespace Personalportfolio.Controllers
{
    [Authorize]
    public class ExperienceController : Controller
    {
        
        private readonly IExperienceService _Service;
        public ExperienceController(IExperienceService service)
        {
            _Service = service;
        }
        public IActionResult Index()
        {
            IEnumerable<Experience> data = _Service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Experience experience)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _Service.Add(experience);
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
            Experience data = _Service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Experience experience)
        {
            _Service.Update(experience);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Experience data = _Service.GetById(id);
            return View(data);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult Deleted(int id)
        {
            _Service.Delete(id);
            return RedirectToAction("Index");
        }


        public IActionResult Details(int id)
        {
            Experience data = _Service.GetById(id);
            return View(data);
        }
    }
}
