using JustBlog.Repositories.Infrastructure;

namespace JustBlog.Repositories.Post
{
    public interface IPostRepository : IGenericRepository<Core.Entities.Post>
    {
        /// <summary>
        /// Get last post inserted
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Core.Entities.Post> GetLatestPost(int size);
        /// <summary>
        /// Get post with category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        IList<Core.Entities.Post> GetPostsByCategory(string category);
        /// <summary>
        /// Get post with tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        IList<Core.Entities.Post> GetPostsByTag(string tag);
        /// <summary>
        /// Get most viewed post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Core.Entities.Post> GetMostViewedPosts(int size);
        /// <summary>
        /// Get highest rated post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Core.Entities.Post> GetHighestPosts(int size);
        /// <summary>
        /// Get all post with category and tags
        /// </summary>
        /// <returns></returns>
        IList<Core.Entities.Post> GetAllPostsWithCategoryAndTags();
        /// <summary>
        /// Add new list tag in post
        /// </summary>
        /// <param name="postId"></param>
        /// <param name="tagIds"></param>
        void AddTags(int postId, IList<int> tagIds);
        /// <summary>
        /// Update tag in post
        /// </summary>
        /// <param name="postId"></param>
        void DeleteTags(int postId);
        /// <summary>
        /// Get post with Tag
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Core.Entities.Post GetPostWithTags(int id);
        /// <summary>
        /// Get post with year and month and url slug
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="urlSlug"></param>
        /// <returns></returns>
        Core.Entities.Post GetDetails(int year, int month, string urlSlug);
    }
}
