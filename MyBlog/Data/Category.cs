using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MyBlogMVC.Data
{
    [Index("SeoUrl", IsUnique = true)]
    public class Category : IEquatable<Category>
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(250)]
        [Required]
        public string Definition { get; set; } = null!;

        [MaxLength(300)]
        [Required]
        public string SeoUrl { get; set; } = null!;

        public List<BlogCategory>? BlogCategories { get; set; }

        public bool Equals(Category? other)
        {
            return this.Definition == other.Definition && this.SeoUrl == other.SeoUrl && this.Id == other.Id;
        }
    }
}
