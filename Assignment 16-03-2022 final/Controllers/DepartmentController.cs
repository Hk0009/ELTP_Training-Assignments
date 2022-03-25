//using Microsoft.AspNetCore.Mvc;
using Assignment_16_03_2022_final.Models;
using Microsoft.AspNetCore.Mvc;
using static Assignment_16_03_2022_final.Services.IService;

namespace Assignment_16_03_2022_final.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IService<Mydatabase, int> deptService;


        //Inject the IService <Department, int> aka Department in it
        public DepartmentController(IService<Mydatabase, int> service)
        {
            deptService = service;
        }
        public IActionResult Index()
        {

            var res = deptService.GetAsync().Result;
            return View(res);
        }

        public IActionResult Create()
        {
            var dept = new Mydatabase();
            return View(dept);
        }
        [HttpPost]
        public IActionResult Create(Mydatabase department)
        {
            var res = deptService.CreateAsync(department).Result;
            return RedirectToAction("Index");
        }


        // the Http get edit request must pass the \
        // route parameter as 'id' (Refer: app.UseEndPoint() in Configure() method of 


        public IActionResult Edit(int id)
        {
            var res = deptService.GetAsync(id).Result;
            // return a view that will show the record to be edited 
            return View(res);
        }



        /// <summary>
        /// Edit the record with Post request
        /// </summary>
        /// <param name="id"></param>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Edit(int id, Mydatabase department)
        {
            var res = deptService.UpdateAsync(id, department).Result;
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
            var res = deptService.GetAsync(id).Result;
            return View(res);
        }
        [HttpPost]
        public IActionResult Delete(int id, Mydatabase departmemt)
        {
            var res = deptService.DeleteAsync(id).Result;
            return RedirectToAction("Index");
        }

    }
}
