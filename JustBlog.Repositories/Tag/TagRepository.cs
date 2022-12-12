using JustBlog.Core.Database;
using JustBlog.Repositories.Infrastructure;

namespace JustBlog.Repositories.Tag
{
    public class TagRepository : GenericRepository<Core.Entities.Tag>, ITagRepository
    {
        public TagRepository(JustBlogContext context) : base(context) { }

        public IList<Core.Entities.Tag> GetTopTags(int size)
        {
            return Context.Tags.OrderByDescending(t => t.PostTagMaps.Count).Take(size).ToList();
        }
    }
}
