using Microsoft.AspNetCore.Mvc;
using Assignment_16_03_2022_final.Models;

using static Assignment_16_03_2022_final.Services.IService;


namespace Assignment_16_03_2022_final.Controllers
{
   
        public class UserController : Controller
        {
            private readonly IService<User1, int> userService;

            //Inject the IService <User, int> aka Employee in it
            public UserController(IService<User1, int> service)
            {
                userService = service;
            }
            public IActionResult Index()
            {
                var res = userService.GetAsync().Result;
                return View(res);
            }
            public IActionResult Create()
            {
                var us1 = new User1();
                return View(us1);
            }
            [HttpPost]
            public IActionResult Create(User1 users)
            {
                var res = userService.CreateAsync(users).Result;
                return RedirectToAction("Index");
            }

            // the Http get edit request must pass the \
            // route parameter as 'id' (Refer: app.UseEndPoint() in Configure() method of 


            public IActionResult Edit(int id)
            {
                var res = userService.GetAsync(id).Result;
                // return a view that will show the record to be edited 
                return View(res);
            }



            /// <summary>
            /// Edit the record with Post request
            /// </summary>
            /// <param name="id"></param>
            /// <param name="user"></param>
            /// <returns></returns>
            [HttpPost]
            public IActionResult Edit(int id, User1 user)
            {
                var res = userService.UpdateAsync(id, user).Result;
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
                var res = userService.GetAsync(id).Result;
                return View(res);
            }
            [HttpPost]
            public IActionResult Delete(int id, User1 user)
            {
                var res = userService.DeleteAsync(id).Result;
                return RedirectToAction("Index");
            }
        }
    }

