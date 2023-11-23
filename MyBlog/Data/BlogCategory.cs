using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyBlogMVC.Data
{
    public class BlogCategory
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey(nameof(Blog))]
        [Required]
        public int BlogId { get; set; }
        public Blog? Blog { get; set; }

        [ForeignKey(nameof(Category))]
        [Required]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }   

    }
}
