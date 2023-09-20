using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Personalportfolio.Data;
using Personalportfolio.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace Personalportfolio.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            var username = User.FindFirstValue(System.Security.Claims.ClaimTypes.Email);

            //  string? nameclaimvalue = HttpContext.User.Claims.FirstOrDefault();

            //var claimsIdentity = (ClaimsIdentity)User.Identity;
            //var claims = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            //var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (username != null)
            {
                var userId = username;
                // Do something with userId...
            }
            //ClaimsPrincipal currentUser = this.User;
            //var currentUserID = currentUser.FindFirst(ClaimTypes.NameIdentifier).Value;

            //var userIds = User.FindFirstValue(ClaimTypes.NameIdentifier);
            //string sessionID = HttpContext.Session.Id;
            var data = _context.Users
                .Include(x => x.SocialMedia)
                .Include(x => x.Awards)
                .Include(x => x.Education)
                .Include(x => x.Experience)
                .Include(x => x.Tools)
                .Include(x => x.WorkFlow)
                .Include(x => x.Interest)
                .FirstOrDefault(x => x.Email == username);
            return View(data);
           
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}