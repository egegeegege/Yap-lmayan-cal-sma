using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    public class MeyveController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
