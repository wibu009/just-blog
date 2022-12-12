using JustBlog.Repositories.Infrastructure;

namespace JustBlog.Repositories.Tag
{
    public interface ITagRepository : IGenericRepository<Core.Entities.Tag>
    {
        /// <summary>
        /// Get top tags for sidebar of post
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        IList<Core.Entities.Tag> GetTopTags(int size);
    }
}
