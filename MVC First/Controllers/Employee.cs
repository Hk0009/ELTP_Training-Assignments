using Microsoft.AspNetCore.Mvc;
using MVC_First.Models;

namespace MVC_First.Controllers
{
    public class Employee : Controller
    {
        EmployeeEnts employees;

        public Employee()
        {
            employees = new EmployeeEnts();
        }
        public IActionResult Index()
        {
            return View(employees);
        }
        public IActionResult Create()
        {
            // pass an EMpty Object
            return View(new EmployeeModels());
        }
        [HttpPost] // The Post method executed fr FOrm Submit
        public IActionResult Create(EmployeeModels emp)
        {
            // Add posted data from UI to collection
            employees.Add(emp);
            // redirect to the Indx method
            return RedirectToAction("Index");
        }

    }
}
