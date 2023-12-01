using System.ComponentModel.DataAnnotations;

namespace MyBlogMVC.Data
{
    public class MyProfile
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public  string Title { get; set; } = null!;
        [Required]
        [MaxLength(500)]
        public  string Summary { get; set; } = null!;
        [Required]
        [MaxLength(250)]
        public  string Contact { get; set; } = null!;
    }
}
