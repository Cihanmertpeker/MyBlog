using Microsoft.AspNetCore.Mvc;
using MyBlogMVC.Controllers.Admin;
using MyBlogMVC.Data;

namespace MyBlogMVC.Controllers
{
    public class BlogController : Controller
    {
        private readonly BlogDbContext context;

        public BlogController(BlogDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult BlogDetail(int id)
        {
            var blogDetail = this.context.Blogs.FirstOrDefault(x=>x.Id == id);
            var myProfile = context.MyProfiles.SingleOrDefault(x => x.Id == (int)enumId.Value);
            ViewBag.ProfileModel = myProfile;
            if (blogDetail != null)
            {
                ViewBag.BlogDetail = blogDetail;

            }
            

            return View();
        }
    }
}
