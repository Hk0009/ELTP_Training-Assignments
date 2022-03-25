using Assignment_16_03_2022_final.Models;
using Microsoft.AspNetCore.Mvc;
using static Assignment_16_03_2022_final.Services.IService;

namespace Assignment_16_03_2022_final.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IService<ComEmployee, int> empService;

        //Inject the IService <Employee, int> aka Employee in it
        public EmployeeController(IService<ComEmployee, int> service)
        {
            empService = service;
        }
        public IActionResult Index()
        {
            var res = empService.GetAsync().Result;
            return View(res);
        }
        public IActionResult Create()
        {
            var emp = new ComEmployee();
            return View(emp);
        }
        [HttpPost]
        public IActionResult Create(ComEmployee employee)
        {
            var res = empService.CreateAsync(employee).Result;
            return RedirectToAction("Index");
        }


        // the Http get edit request must pass the \
        // route parameter as 'id' (Refer: app.UseEndPoint() in Configure() method of 


        public IActionResult Edit(int id)
        {
            var res = empService.GetAsync(id).Result;
            // return a view that will show the record to be edited 
            return View(res);
        }



        /// <summary>
        /// Edit the record with Post request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employee"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(int id, ComEmployee employee)
        {
            var res = empService.UpdateAsync(id, employee).Result;
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Http Get Request that will accept an id of record to delete 
        /// and return a veiw that will show the record to be deleted
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int id)
        {
            var res = empService.GetAsync(id).Result;
            return View(res);
        }
        [HttpPost]
        public IActionResult Delete(int id, ComEmployee employee)
        {
            var res = empService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }
    }
}
