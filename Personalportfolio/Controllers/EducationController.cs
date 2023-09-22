using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;
using System.Security.Claims;

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
        public async Task<IActionResult> CreateAsync(Education education)
        {


            if (ModelState.IsValid)
            {
                try
                {

                    await _service.AddAsync(education);
                    return RedirectToAction("Index");



                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return View(education);
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
            Education data = _service.GetById(id);
            return View(data);
        }
    }
}
