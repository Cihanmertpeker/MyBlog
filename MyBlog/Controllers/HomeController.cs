using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogMVC.Controllers.Admin;
using MyBlogMVC.Data;
using MyBlogMVC.Models;
using System.Linq;
using System.Text.Json;

namespace MyBlogMVC.Controllers
{
    public class HomeController:Controller
    {
        private readonly BlogDbContext context;

        public HomeController(BlogDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(BlogSearchModel model)
        {
            ViewBag.SearchModel = model;
            ViewBag.Active = "Blog";

            var categories = GetCategories().Value;
            ViewBag.Categories = categories;

            //cats = JsonSerializer.Deserialize<List<Category>>(categories);
            var existingModel = new ProfileUpdateModel();
            var updatedProfile = context.MyProfiles.SingleOrDefault(x => x.Id == (int)enumId.Value);
            existingModel.Id = updatedProfile.Id;
            existingModel.Summary = updatedProfile.Summary;
            existingModel.Contact = updatedProfile.Contact;
            existingModel.Title = updatedProfile.Title;
            ViewBag.ProfileModel = existingModel;


            

            var query = this.context.Blogs.Include(x => x.BlogCategories).AsQueryable();

            
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                query = query.Where(x => x.Title.Contains(model.Title));
            }


            ViewBag.PageModel = new PageModel
            {
                ActivePage = model.ActivePage,

                PageCount = (int)Math.Ceiling((decimal)(query.Count()) / model.PageSize),

                PageSize = model.PageSize
            };

            

            if (model.CategoryId != null)
            {

                var blogIds = this.context.BlogCategories.AsNoTracking().Where(x => x.CategoryId == model.CategoryId).Select(x => x.BlogId).ToList();

                query = query.Where(x => blogIds.Contains(x.Id));
            }

            var blogs = query.Skip((model.ActivePage - 1) * model.PageSize).Take(model.PageSize).ToList();



            return View(blogs);
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

 