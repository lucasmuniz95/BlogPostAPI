namespace BlogPostAPI.Models
{
    public class BlogPostModel
    {
        public int Id { get; init; }
        public string titulo { get; set; }
        public string conteudo { get; set; }
        public List<CommentModel> comments { get; set; } = new List<CommentModel>();

    }
}
