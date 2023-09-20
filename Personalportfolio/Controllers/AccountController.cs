using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Personalportfolio.Data;
using Personalportfolio.Models;
using Personalportfolio.Models.ViewModel;
using System.Security.Claims;

namespace Personalportfolio.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost, ActionName("Register")]
        public IActionResult Registered(User user)
        {
            _context.Users.Add(user);   
            _context.SaveChanges();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            User data = _context.Users.FirstOrDefault(x => x.Email == user.Email && x.Password == user.Password);
            if (data.Email != null && data.Password != null)
            {
                List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, user.Email),
            };

                ClaimsIdentity identity = new ClaimsIdentity(new[]
                {
              new Claim(ClaimTypes.Email, user.Email),
              new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())

            }, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal).Wait();

                return RedirectToAction("Index", "Home");
            }
            return View();

        }
    }
}
