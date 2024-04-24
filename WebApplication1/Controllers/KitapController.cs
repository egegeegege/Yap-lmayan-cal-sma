using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class KitapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
