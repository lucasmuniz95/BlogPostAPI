namespace BlogPostAPI.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string texto { get; set; }
        public int BlogPostId { get; set; }
        public BlogPostModel BlogPost { get; set; }
    }
}
