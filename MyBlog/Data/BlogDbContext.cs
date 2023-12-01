using Microsoft.EntityFrameworkCore;

namespace MyBlogMVC.Data
{
    public class BlogDbContext:DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options):base(options)
        {
            {
            }
            
        }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<MyProfile> MyProfiles { get; set; }


    }
}
