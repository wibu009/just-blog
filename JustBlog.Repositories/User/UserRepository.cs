using JustBlog.Core.Database;
using JustBlog.Repositories.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Repositories.User
{
    public class UserRepository : GenericRepository<Core.Entities.User>, IUserRepository
    {
        public UserRepository(JustBlogContext context) : base(context)
        {
        }

        public IList<IdentityRole> GetRoles(string id)
        {
            var roleIds = Context.UserRoles.Where(ur => ur.UserId == id).Select(ur => ur.RoleId).ToList();
            return Context.Roles.Where(r => roleIds.Contains(r.Id)).ToList();
        }
        public void AddRoles(string id, IList<string> roleIds)
        {
            var userRoles = roleIds.Select(roleId => new IdentityUserRole<string>
            {
                UserId = id,
                RoleId = roleId
            });
            Context.UserRoles.AddRange(userRoles);
        }

        public void DeleteRoles(string id)
        {
            Context.UserRoles.RemoveRange(Context.UserRoles.Where(ur => ur.UserId == id));
        }
    }
}
