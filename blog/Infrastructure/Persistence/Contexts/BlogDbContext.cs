using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Category>()
                .HasOne(category => category.ParentCategory)
                .WithMany(category => category.SubCategories)
                .HasForeignKey(category => category.ParentCategoryId);

            modelBuilder
                .Entity<Article>()
                .HasOne(article => article.Category)
                .WithMany(category => category.Article);

            modelBuilder
                .Entity<Article>()
                .HasMany(article => article.Comments)
                .WithOne(comment => comment.Article);

            modelBuilder
                .Entity<Comment>()
                .HasOne(childComment => childComment.ParentComment)
                .WithMany(commet => commet.ChildComment);  
        }
    }
}
