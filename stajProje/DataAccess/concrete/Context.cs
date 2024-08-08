using Entities.concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.concrete
{
    public class Context:IdentityDbContext<User,Role,int>
    {
      public Context(DbContextOptions options) :base(options){ }
      
        public DbSet<Category> Categories { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<AuthorAbout>  AuthorAbouts { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AuthorAbout>()
                .HasOne(aa => aa.Author)
                .WithOne(u => u.AuthorAbout)
                .HasForeignKey<AuthorAbout>(aa => aa.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Author)
                .WithMany(u => u.Blogs)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            // Blog - Category (Many-to-One)
            modelBuilder.Entity<Blog>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Blogs)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            // Comment - Blog (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Blog)
                .WithMany(b => b.Comments)
                .HasForeignKey(c => c.BlogId)
                .OnDelete(DeleteBehavior.NoAction);

            // Comment - User (Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            // Comment - Comment (Self-referencing Many-to-One)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.ParentComment)
                .WithMany(c => c.Replies)
                .HasForeignKey(c => c.ParentCommentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<Role>().HasData(
          new Role { Id = 1, Name = "User", NormalizedName = "USER" },
          new Role { Id = 2, Name = "Admin", NormalizedName = "ADMIN" },
          new Role { Id = 3, Name = "Author", NormalizedName = "AUTHOR" }
        );



        }
    }
}
