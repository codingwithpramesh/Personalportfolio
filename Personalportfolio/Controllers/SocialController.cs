using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;

namespace Personalportfolio.Controllers
{
    [Authorize]
    public class SocialController : Controller
    {
        private readonly ISocialService _service;
        public SocialController(ISocialService service) 
        {
            _service = service;
        }
        public IActionResult Index()
        {
            IEnumerable<SocialMedia> data = _service.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SocialMedia social, IFormFile file)
        {
            try
            {
                await _service.AddAsync(social, file);
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
            SocialMedia data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(SocialMedia social)
        {
            _service.Update(social);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            SocialMedia data = _service.GetById(id);
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
            SocialMedia data = _service.GetById(id);
            return View(data);
        }
    }
}
