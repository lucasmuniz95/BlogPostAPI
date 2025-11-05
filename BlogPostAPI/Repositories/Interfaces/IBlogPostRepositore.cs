using BlogPostAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlogPostAPI.Repositories.Interfaces
{
    public interface IBlogPostRepositore
    {
        Task<List<BlogPostModel>> BuscarTodosPosts();
        Task<BlogPostModel> BuscarPorId(int id);
        Task<BlogPostModel> AdicionarPost(BlogPostModel blogPost);
        Task<BlogPostModel> AtualizarPost(BlogPostModel blogPost, int id);
        Task<CommentModel> AdicionarComentario(CommentModel comment, int id);
        Task<bool> DeletarPost(int id);
    }
}
