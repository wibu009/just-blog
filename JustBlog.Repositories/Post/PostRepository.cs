using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace JustBlog.Repositories.Post
{
    public class PostRepository : GenericRepository<Core.Entities.Post>, IPostRepository
    {
        public PostRepository(JustBlogContext context) : base(context) { }

        public IList<Core.Entities.Post> GetLatestPost(int size)
        {
            return Context.Posts!.OrderByDescending(p => p.PostedOn).Take(size).ToList();
        }
        public IList<Core.Entities.Post> GetPostsByMonth(DateTime monthYear)
        {
            return Context.Posts!.Where(p => p.PostedOn.Month == monthYear.Month).ToList();
        }
        public IList<Core.Entities.Post> GetPostsByCategory(string category)
        {
            return Context.Posts!.Where(p => p.Category!.UrlSlug == category).Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).ToList();
        }
        public IList<Core.Entities.Post> GetPostsByTag(string tag)
        {
            return Context.Tags!.Where(t => t.UrlSlug == tag).SelectMany(t => t.PostTagMaps.Select(ptm => ptm.Post)).Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).ToList();
        }

        public IList<Core.Entities.Post> GetMostViewedPosts(int size)
        {
            return Context.Posts!.OrderByDescending(p => p.ViewCount).Take(size).ToList();
        }
        public IList<Core.Entities.Post> GetHighestPosts(int size)
        {
            return Context.Posts!.AsEnumerable().OrderByDescending(p => p.Rate).Take(size).ToList();
        }
        public IList<Core.Entities.Post> GetAllPostsWithCategoryAndTags()
        {
            return Context.Posts!.Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).ToList();
        }

        public void AddTags(int postId, IList<int> tagIds)
        {
            var postTagMaps = tagIds.Select(tagId => new PostTagMap
            {
                PostId = postId,
                TagId = tagId
            });
            Context.PostTagMaps.AddRange(postTagMaps);
        }

        public void DeleteTags(int postId)
        {
            Context.PostTagMaps.RemoveRange(Context.PostTagMaps.Where(ptm => ptm.PostId == postId));
        }
        public Core.Entities.Post GetPostWithTags(int id)
        {
            return Context.Posts.Include(p => p.PostTagMaps).First(p => p.Id == id);
        }
        public Core.Entities.Post GetDetails(int year, int month, string urlSlug)
        {
            return Context.Posts.Include(p => p.Category).Include(p => p.PostTagMaps).ThenInclude(ptm => ptm.Tag).Include(p => p.Comments).First(p => p.PostedOn.Year == year && p.PostedOn.Month == month && p.UrlSlug == urlSlug);
        }
    }
}
