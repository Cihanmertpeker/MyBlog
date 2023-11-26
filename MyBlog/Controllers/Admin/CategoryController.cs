using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlogMVC.Data;

namespace MyBlogMVC.Controllers.Admin
{
    public enum ViewType
    {
        Create = 0,
        Update = 1,
    }


    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly BlogDbContext context;

        public CategoryController(BlogDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Active = "Category";
            var categories = this.context.Categories.AsNoTracking().ToList();
            return View(categories);
        }


        public IActionResult CreateOrUpdate(int id, ViewType type)
        {
            ViewBag.Active = "Category";
            ViewBag.type = type;

            if (type == ViewType.Update)
            {
                var updatedCategory = this.context.Categories.AsNoTracking().SingleOrDefault(x => x.Id == id);
                return View(updatedCategory);
            }
            else
            {
                return View(new Category());
            }

        }

        [HttpPost]
        public IActionResult CreateOrUpdate(Category category)
        {
            ViewBag.Active = "Category";
            if (category.Id == 0)
            {
                category.SeoUrl = ConvertSeoUrl(category.Definition);
                this.context.Categories.Add(category);
                this.context.SaveChanges();
            }
            else
            {
                var updatedEntity = this.context.Categories.SingleOrDefault(x => x.Id == category.Id);

                if (updatedEntity != null)
                {
                    if (updatedEntity.Definition != category.Definition)
                    {
                        updatedEntity.Definition = category.Definition;
                        updatedEntity.SeoUrl = ConvertSeoUrl(category.Definition);
                    }
                    this.context.SaveChanges();
                }

            }
            return RedirectToAction("Index");

        }

        public IActionResult Remove(int id) 
        {
            ViewBag.Active = "Category";
            var deletedCategory = this.context.Categories.SingleOrDefault(x => x.Id == id);
            this.context.Categories.Remove(deletedCategory);
            this.context.SaveChanges();

            return RedirectToAction("Index");
        }

        private string ConvertSeoUrl(string definition)
        {
            definition = definition.ToLower().Replace(' ', '-');
            definition = definition.Replace('ş', 's');
            definition = definition.Replace('ç', 'c');
            definition = definition.Replace('ı', 'i');
            definition = definition.Replace('ü', 'u');
            definition = definition.Replace('ö', 'o');
            definition = definition.Replace('ğ', 'g');

            return definition;
        }

    }
}
