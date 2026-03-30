using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;

namespace YourApp.Controllers
{
    public class AccountController : Controller
    {
        // GET: Display login page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Handle login
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "srija" && model.Password == "12345")
                {
                    return RedirectToAction("Success");
                }
                else
                {
                    ViewBag.Message = "Invalid Login";
                }
            }
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}
