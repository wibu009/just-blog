using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;

namespace JustBlog.Repositories.Comment
{
    public interface ICommentRepository : IGenericRepository<Core.Entities.Comment>
    {
        /// <summary>
        /// Get comments of post with postId
        /// </summary>
        /// <param name="postId"></param>
        /// <returns></returns>
        IList<Core.Entities.Comment> GetCommentsForPost(int postId);
        /// <summary>
        /// Get comments of a post
        /// </summary>
        /// <param name="post"></param>
        /// <returns></returns>
        IList<Core.Entities.Comment> GetCommentsForPost(Core.Entities.Post post);
        void Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody);
    }
}
