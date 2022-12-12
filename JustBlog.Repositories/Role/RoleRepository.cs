using JustBlog.Core.Database;
using JustBlog.Repositories.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Repositories.Role
{
    public class RoleRepository : GenericRepository<IdentityRole>, IRoleRepository
    {
        public RoleRepository(JustBlogContext context) : base(context)
        {
        }
    }
}
