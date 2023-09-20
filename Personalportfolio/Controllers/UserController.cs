using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Personalportfolio.Data;
using Personalportfolio.Data.Service;
using Personalportfolio.Models;
using System.Security.Claims;

namespace Personalportfolio.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _service;
        private readonly ApplicationDbContext _context;
        public UserController(IUserService service , ApplicationDbContext context)
        {
            _service = service;
            _context = context;
            
        }
        [HttpGet]
        public IActionResult Index()
        {
            var username = User.FindFirstValue(System.Security.Claims.ClaimTypes.Email);

            if (username != null)
            {
                var userId = username;
              
            }

            var data = _context.Users.FirstOrDefault(x => x.Email == username);
            return View(data);
        }

        [HttpPost, ActionName("Index")]
        public IActionResult Indexed( User user)
        {
            /* var data = _service.GetAll().ToList();
             return View(data);*/

            _service.Update(user);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user, IFormFile file)
        {
            try
            {
                await _service.AddAsync(user, file);
                return RedirectToAction("Login","Account" );

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
            User data = _service.GetById(id);
            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            _service.Update(user);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            User data = _service.GetById(id);
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
            User data = _service.GetById(id);
            return View(data);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        public IActionResult Registered()
        {
            return View();
        }



       /* [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> login(LoginVm loginvm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginvm);
            }

            var data = await _service.Login(loginvm);

            if (data.statuscode == 1)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }

            //  var result = await _context.LoginAsync;

        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
               
                var re = await _service.Register(register);
                return RedirectToAction("Register", "Account");

            }
        }

        public async Task<IActionResult> Logout()
        {
            await _service.LogoutAsync();
            return RedirectToAction("Login", "Account");
        }*/


    }
}
