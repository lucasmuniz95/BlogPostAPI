using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogPostAPI.Models;
using BlogPostAPI.Repositories.Interfaces;

namespace BlogPostAPI.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostRepositore _blogPostRepositore;

        public BlogPostController(IBlogPostRepositore blogPostRepositore)
        {
            _blogPostRepositore = blogPostRepositore;
        }

        [HttpGet]
        public async Task<ActionResult<List<BlogPostModel>>> BuscarTodosPosts()
        {
            List<BlogPostModel> posts = await _blogPostRepositore.BuscarTodosPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BlogPostModel>> BuscarPorId(int id)
        {
            BlogPostModel post = await _blogPostRepositore.BuscarPorId(id);
            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult<BlogPostModel>> Adicionar([FromBody] BlogPostModel blogPost)
        {
            BlogPostModel blogPostCreate = await _blogPostRepositore.AdicionarPost(blogPost);

            return Ok(blogPostCreate);
        }

        [HttpPost("{id}/comments")]        
        public async Task<ActionResult<CommentModel>> AdicionarComentario(int id, [FromBody] CommentModel comment)
        {
            CommentModel comentNew = await _blogPostRepositore.AdicionarComentario(comment, id);

            return Ok(comentNew);
        }
    }
}
