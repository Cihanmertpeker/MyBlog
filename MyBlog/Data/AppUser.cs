using System.ComponentModel.DataAnnotations;

namespace MyBlogMVC.Data
{
    public class AppUser
    {
       
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(100)]
        public string Password { get; set; } = null!;
    }
}
