using System.ComponentModel.DataAnnotations;

namespace MyBlogMVC.Models
{
    public class ProfileUpdateModel
    {
        public int Id { get; set; }
        
        public string? Title { get; set; }
        public string? Summary { get; set; }
        
        public string? Contact { get; set; }
    }
}
