using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreStart.Models
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public DbSet<BlogPost> BlogPosts { get; set; }
        //Used by EF Core to create a Categories table in the DB. Additionally, LINQ can 
        //select category data using this DbSet, Categories.
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = "P", Name = "Programming" },
                new Category { CategoryId = "S", Name = "Sport" },
                new Category { CategoryId = "M", Name = "Music" });

            modelBuilder.Entity<BlogPost>().HasData(
                new BlogPost
                {
                    Author = "Erik Martines Sanches",
                    BlogPostId = 1,
                    CategoryId = "P",
                    Post = "My programming post, hi world.",
                    Time = DateTime.Now,
                    Title = "A programming post"
                },
                new BlogPost
                {
                    Author = "Erik Martines Sanches",
                    BlogPostId = 2,
                    CategoryId = "S",
                    Post = "My sports post, hi world.",
                    Time = DateTime.Now,
                    Title = "A sports post"
                },
                new BlogPost
                {
                    Author = "Erik Martines Sanches",
                    BlogPostId = 3,
                    CategoryId = "M",
                    Post = "My music post, hi world.",
                    Time = DateTime.Now,
                    Title = "A music post"
                });
        }

    }
}
