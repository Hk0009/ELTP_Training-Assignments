using Microsoft.AspNetCore.Mvc;

namespace Assignment_15_03_2022.Controllers
{
    public class FirstController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
