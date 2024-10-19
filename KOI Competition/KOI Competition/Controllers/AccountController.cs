
using KOI_Competition.Data;
using KOI_Competition.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KOI_Competition.Controllers
{
    public class AccountController : Controller
    {
        private readonly KOI_CompetitionContext _context;

        public AccountController(KOI_CompetitionContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(User _userFromPage)
        {
            var _user = _context.User.Where(m => m.UserEmail == _userFromPage.UserEmail && m.UserPassword == _userFromPage.UserPassword).FirstOrDefault();
            if (_user == null)
            {
                ViewBag.LoginStatus = 0;
            }
            else 
            {
                var claims = new List<Claim>
                {
                 new Claim(ClaimTypes.Name, _user.UserEmail),
                 new Claim("FullName", _user.UserName),
                 new Claim(ClaimTypes.Role, _user.UserRole),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    
                };

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Account"); 
            }
            return View();
        }
    }
}
