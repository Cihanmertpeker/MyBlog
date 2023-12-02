namespace MyBlogMVC.Models
{
    public class BlogSearchModel:PageModel
    {
        public  string? Title { get; set; }
        public DateTime CreatedDate { get; set; }

        public int? CategoryId { get; set; }
    }
}
