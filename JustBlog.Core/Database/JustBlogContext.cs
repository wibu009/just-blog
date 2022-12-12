using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JustBlog.Core.Config;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using JustBlog.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Core.Database
{
    public sealed class JustBlogContext : IdentityDbContext<User>
    {
        public JustBlogContext() { }
        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName!.StartsWith("AspNet"))
                {
                    entityType.SetTableName(tableName.Substring(6));
                }
            }

            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new PostConfig());
            modelBuilder.ApplyConfiguration(new TagConfig());
            modelBuilder.ApplyConfiguration(new PostTagMapConfig());
            modelBuilder.ApplyConfiguration(new CommentConfig());

            modelBuilder.SeedData();
        }

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Post>? Posts { get; set; }
        public DbSet<Tag>? Tags { get; set; }
        public DbSet<PostTagMap>? PostTagMaps { get; set; }
        public DbSet<Comment>? Comments { get; set; }
    }
}