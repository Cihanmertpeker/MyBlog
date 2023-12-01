using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using MyBlogMVC.Data;
using MyBlogMVC.Models;

namespace MyBlogMVC.Controllers.Admin
{

    public enum enumId
    {
        Value = 3,
        
    }

    [Authorize]
    [Area("Admin")]
    public class ProfileController : Controller
    {
        private readonly BlogDbContext context;

        public ProfileController(BlogDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index(ProfileUpdateModel model)
        {


            var profile = this.context.MyProfiles.AsNoTracking().ToList();

            return View("Index");
        }

        public IActionResult Update()
        {
            var existingModel = new ProfileUpdateModel();
            var updatedProfile = context.MyProfiles.SingleOrDefault(x => x.Id == (int)enumId.Value);
            existingModel.Id = updatedProfile.Id;
            existingModel.Summary = updatedProfile.Summary;
            existingModel.Contact = updatedProfile.Contact;
            existingModel.Title = updatedProfile.Title;
            
            return View(existingModel);
          

        }
        [HttpPost]
        public IActionResult Update(ProfileUpdateModel model)
        {
            var updatedProfile = this.context.MyProfiles.SingleOrDefault(x => x.Id == model.Id);

            updatedProfile.Title = model.Title;
            updatedProfile.Summary = model.Summary;
            updatedProfile.Contact = model.Contact;
            this.context.SaveChanges();

            return RedirectToAction("Index","Blog");
        }
    }
}
