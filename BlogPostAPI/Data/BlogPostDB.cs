using BlogPostAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPostAPI.Data
{
    public class BlogPostDB : DbContext
    {
        public BlogPostDB(DbContextOptions<BlogPostDB> options) : base(options) { }

        public DbSet<BlogPostModel> posts { get; set; }

        public DbSet<CommentModel> coments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
