using Microsoft.AspNetCore.Mvc;

namespace KOI_Competition.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
