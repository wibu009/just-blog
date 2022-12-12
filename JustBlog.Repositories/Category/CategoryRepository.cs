using JustBlog.Core.Database;
using JustBlog.Repositories.Infrastructure;

namespace JustBlog.Repositories.Category
{
    public class CategoryRepository : GenericRepository<Core.Entities.Category>, ICategoryRepository
    {
        public CategoryRepository(JustBlogContext context) : base(context)
        {

        }
    }
}