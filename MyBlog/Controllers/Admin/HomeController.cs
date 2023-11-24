using Microsoft.AspNetCore.Mvc;

namespace MyBlogMVC.Controllers.Admin
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
