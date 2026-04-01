using Microsoft.AspNetCore.Mvc;

namespace WebApplication4.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        [HttpPost("form")]
        public IActionResult Form(string name, string comments, int rating)
        {
            if (rating >= 4)
                ViewData["Message"] = "Thank You";
            else
                ViewData["Message"] = "We will improve";

            return View();
        }
    }
}