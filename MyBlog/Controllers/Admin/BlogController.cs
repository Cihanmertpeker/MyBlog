using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogMVC.Data;
using MyBlogMVC.Models;

namespace MyBlogMVC.Controllers.Admin
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly BlogDbContext context;

        public BlogController(BlogDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(BlogSearchModel model)
        {
            ViewBag.Active = "Blog";
           
            var query = this.context.Blogs.AsQueryable();

            if (model.CreatedDate != DateTime.MinValue)
            {
              query = query.Where(x => x.CreatedDate.Date == model.CreatedDate);
            }
            if (!string.IsNullOrWhiteSpace(model.Title))
            {
                query = query.Where(x => x.Title.Contains(model.Title));
            }

            ViewBag.PageModel = new PageModel
            {
                ActivePage = model.ActivePage,
                PageCount =(int)Math.Ceiling((decimal)(query.Count())/model.PageSize),
                PageSize=model.PageSize
            };

            var blogs = query.Skip((model.ActivePage-1)*model.PageSize).Take(model.PageSize).ToList();

            return View(blogs);
        }
    }
}
