using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;

namespace Personalportfolio.Controllers
{
    [Authorize]
    public class InterestController : Controller
    {
        private readonly IInterestService _service;
        public InterestController( IInterestService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            IEnumerable<Interest> data = _service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Interest interest)
        {
            try
            {
                _service.Add(interest);
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
            Interest data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Interest interest)
        {
            _service.Update(interest);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            Interest data = _service.GetById(id);
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
            Interest data = _service.GetById(id);
            return View(data);
        }
    }
}
