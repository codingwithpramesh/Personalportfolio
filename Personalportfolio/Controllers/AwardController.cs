using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Personalportfolio.Data;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;
using Personalportfolio.Models.ViewModel;
using System.Security.Claims;

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

            var userId = User.FindFirstValue("userId");
            IEnumerable<Awards> data = _service.GetAll().Where(x=>x.UId.ToString() == userId).ToList();
            return View(data);
        }


        [HttpGet]
        public IActionResult FinalTest()
        {

            var userId = User.FindFirstValue("userId");
            IEnumerable<Awards> data = _service.GetAll().Where(x => x.UId.ToString() == userId);
            return View(data);
        }


        [HttpGet]
        public IActionResult Create()
        {
            var usermail = User.FindFirstValue("userId");
            ViewBag.email = usermail;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Awards awards)
        {

            if (ModelState.IsValid)
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
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var usermail = User.FindFirstValue("userId");
            Awards data = _service.GetById(id);
              if(data.UId.ToString() == usermail)
            {
                return View(data);
            }
            return View();
           
        }

        [HttpPost]
        public IActionResult Edit(Awards awards)
        {
            if(ModelState.IsValid)
            {
                _service.Update(awards);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
           
        }

        public async Task<IActionResult> Delete(int id)
        {
            Awards data = _service.GetById(id);
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
            Awards data = _service.GetById(id);
            return View(data);
        }
    }
}
