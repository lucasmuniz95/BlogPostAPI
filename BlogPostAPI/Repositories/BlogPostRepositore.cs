using BlogPostAPI.Data;
using BlogPostAPI.Models;
using BlogPostAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BlogPostAPI.Repositories
{
    public class BlogPostRepositore : IBlogPostRepositore
    {
        private readonly BlogPostDB _dbContext;
        public BlogPostRepositore(BlogPostDB blogPostDB)
        {
            _dbContext = blogPostDB;
        }

        public async Task<BlogPostModel> BuscarPorId(int id)
        {
            return await _dbContext.posts.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<BlogPostModel>> BuscarTodosPosts()
        {
            return await _dbContext.posts.ToListAsync();
        }
        public async Task<BlogPostModel> AdicionarPost(BlogPostModel blogPost)
        {
            _dbContext.posts.Add(blogPost);
            await _dbContext.SaveChangesAsync();

            return blogPost;
        }

        public async Task<BlogPostModel> AtualizarPost(BlogPostModel blogPost, int id)
        {
            BlogPostModel blogpostId = await BuscarPorId(id);

            if (blogpostId == null)
            {
                throw new Exception("Nào foi encontrado post com esse id");
            }

            blogpostId.titulo = blogPost.titulo;
            blogpostId.conteudo = blogPost.conteudo;
            blogpostId.comments = blogPost.comments;

            _dbContext.posts.Update(blogpostId);
            await _dbContext.SaveChangesAsync();

            return blogpostId;
        }       

        public async Task<bool> DeletarPost(int id)
        {
            BlogPostModel blogpostId = await BuscarPorId(id);

            if (blogpostId == null)
            {
                throw new Exception("Nào foi encontrado post com esse id");
            }

            _dbContext.posts.Remove(blogpostId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<CommentModel> AdicionarComentario(CommentModel comment, int id)
        {
            var post = await _dbContext.posts.Include(p => p.comments).FirstOrDefaultAsync(p => p.Id == id);

            if (post == null)
                throw new Exception("Post não encontrado");

            comment.BlogPostId = id;
            _dbContext.Add(comment);
            await _dbContext.SaveChangesAsync();

            return comment;
        }
    }
}
