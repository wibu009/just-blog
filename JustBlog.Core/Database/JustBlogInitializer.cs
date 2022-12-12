using JustBlog.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JustBlog.Core.Database
{
    public static class JustBlogInitializer
    {
        public static void SeedData(this ModelBuilder builder)
        {
            List<Category> categories = new List<Category>();
            List<Post> posts = new List<Post>();
            List<Tag> tags = new List<Tag>();
            List<PostTagMap> postTags = new List<PostTagMap>();
            List<Comment> comments = new List<Comment>();

            // Categories
            for (int i = 1; i <= 10; i++)
            {
                categories.Add(new Category
                {
                    Id = i,
                    Name = LoremNET.Lorem.Words(2),
                    UrlSlug = LoremNET.Lorem.Words(2).ToLower().Replace(' ', '-'),
                    Description = LoremNET.Lorem.Words(12)
                });
            }

            // Posts
            for (int i = 1; i <= 10; i++)
            {
                posts.Add(new Post
                {
                    Id = i,
                    Title = LoremNET.Lorem.Words(3),
                    UrlSlug = LoremNET.Lorem.Words(3).ToLower().Replace(' ', '-'),
                    ShortDescription = LoremNET.Lorem.Words(13),
                    PostContent = LoremNET.Lorem.Paragraph(10, 20, 4, 8),
                    PostedOn = LoremNET.Lorem.DateTime(DateTime.Now.AddDays(-10), DateTime.Now),
                    Published = true,
                    CategoryId = LoremNET.RandomHelper.Instance.Next(1, 6),
                    RateCount = LoremNET.RandomHelper.Instance.Next(10, 30),
                    TotalRate = LoremNET.RandomHelper.Instance.Next(100, 300),
                    ViewCount = LoremNET.RandomHelper.Instance.Next(100, 300),
                });
            }

            // Tags
            for (int i = 1; i <= 10; i++)
            {
                tags.Add(new Tag
                {
                    Id = i,
                    Name = LoremNET.Lorem.Words(3),
                    UrlSlug = LoremNET.Lorem.Words(3).ToLower().Replace(' ', '-'),
                    Description = LoremNET.Lorem.Words(13),
                    Count = LoremNET.RandomHelper.Instance.Next(10, 30)
                });
            }

            // PostTags
            for (int i = 1; i <= 10; i++)
            {
                postTags.Add(new PostTagMap
                {
                    PostId = posts[i-1].Id,
                    TagId = tags[i-1].Id
                });
            }

            // Comments
            for (int i = 1; i <= 10; i++)
            {
                comments.Add(new Comment
                {
                    Id = i,
                    CommentHeader = LoremNET.Lorem.Words(3),
                    CommentText = LoremNET.Lorem.Paragraph(10, 20, 1, 3),
                    CommentTime = LoremNET.Lorem.DateTime(DateTime.Now.AddDays(-10), DateTime.Now),
                    Email = LoremNET.Lorem.Email(),
                    Name = LoremNET.Lorem.Words(2),
                    PostId = LoremNET.RandomHelper.Instance.Next(1, 10),
                });
            }

            //Roles
            var roles = new IdentityRole[]
            {
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Blog Owner",
                    NormalizedName = "Blog Owner".ToUpper()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Contributor",
                    NormalizedName = "Contributor".ToUpper()
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "User",
                    NormalizedName = "User".ToUpper()
                },
                new IdentityRole
                {
                Id = Guid.NewGuid().ToString(),
                Name = "Admin",
                NormalizedName = "ADMIN"
                }
            };
            
            //Users
            var users = new User[]
            {
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Age = LoremNET.RandomHelper.Instance.Next(20, 60),
                    AboutMe = LoremNET.Lorem.Words(10),
                    UserName = "kienct5",
                    NormalizedUserName = "kienct5".ToUpper(),
                    Email = "kienct5@gmail.com",
                    NormalizedEmail = "kienct5@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null!, "Animelol09")
},
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Age = LoremNET.RandomHelper.Instance.Next(20, 60),
                    AboutMe =  LoremNET.Lorem.Words(10),
                    UserName = "kienct6",
                    NormalizedUserName = "kienct6".ToUpper(),
                    Email = "kienct6@gmail.com",
                    NormalizedEmail = "kienct6@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null!, "Animelol09")
                },
                new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Age = LoremNET.RandomHelper.Instance.Next(20, 60),
                    AboutMe =  LoremNET.Lorem.Words(10),
                    UserName = "kienct7",
                    NormalizedUserName = "kienct7".ToUpper(),
                    Email = "kienct7@gmail.com",
                    NormalizedEmail = "kienct6@gmail.com".ToUpper(),
                    EmailConfirmed = true,
                    AccessFailedCount = 0,
                    PasswordHash = new PasswordHasher<User>().HashPassword(null!, "Animelol09")
                },
            };

            //UserRoles
            var userRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>
                {
                    RoleId = roles[0].Id,
                    UserId = users[0].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = roles[1].Id,
                    UserId = users[1].Id
                },
                new IdentityUserRole<string>
                {
                    RoleId = roles[2].Id,
                    UserId = users[2].Id
                }
            };

            //Seed data
            builder.Entity<Category>().HasData(categories);
            builder.Entity<Post>().HasData(posts);
            builder.Entity<Tag>().HasData(tags);
            builder.Entity<PostTagMap>().HasData(postTags);
            builder.Entity<Comment>().HasData(comments);
            builder.Entity<User>().HasData(users);
            builder.Entity<IdentityRole>().HasData(roles);
            builder.Entity<IdentityUserRole<string>>().HasData(userRoles);
        }
    }
}