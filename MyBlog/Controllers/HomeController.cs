using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogMVC.Controllers.Admin;
using MyBlogMVC.Data;
using MyBlogMVC.Models;

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
            var existingModel = new ProfileUpdateModel();
            var updatedProfile = context.MyProfiles.SingleOrDefault(x => x.Id == (int)enumId.Value);
            existingModel.Id = updatedProfile.Id;
            existingModel.Summary = updatedProfile.Summary;
            existingModel.Contact = updatedProfile.Contact;
            existingModel.Title = updatedProfile.Title;
            ViewBag.ProfileModel = existingModel;


            var allBlogs = this.context.Blogs.AsNoTracking().ToList();
            ViewBag.AllBlogs= allBlogs;

            return View();
        }


        [HttpGet]
        public JsonResult GetCategories()
        {
            Thread.Sleep(2000);

            var categories = this.context.Categories.AsNoTracking().ToList();

            return Json(categories);
        }

       
    }
}

 