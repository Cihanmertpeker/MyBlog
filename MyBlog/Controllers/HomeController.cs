using Microsoft.AspNetCore.Mvc;
using MyBlogMVC.Data;

namespace MyBlogMVC.Controllers
{
    public class HomeController:Controller
    {
        private readonly BlogDbContext context;

        public HomeController(BlogDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {           
            return View();
        }
    }
}
 