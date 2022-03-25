using Microsoft.AspNetCore.Mvc;
using Assignment_15_03_2022.Models;

namespace Assignment_15_03_2022.Controllers
{
    public class EmployeeEnt : Controller
    {
        EmployeeEnts employees;

        public EmployeeEnt()
        {
            employees = new EmployeeEnts();
        }
        public IActionResult Index()
        {
           return View(employees);

        }
    }
}
