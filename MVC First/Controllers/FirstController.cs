using Microsoft.AspNetCore.Mvc;

namespace MVC_First.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
