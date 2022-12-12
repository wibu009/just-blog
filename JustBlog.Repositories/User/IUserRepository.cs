using JustBlog.Repositories.Infrastructure;
using Microsoft.AspNetCore.Identity;

namespace JustBlog.Repositories.User
{
    public interface IUserRepository : IGenericRepository<Core.Entities.User>
    {
        /// <summary>
        /// Get role of user
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IList<IdentityRole> GetRoles(string id);
        /// <summary>
        /// Add role
        /// </summary>
        /// <param name="id"></param>
        /// <param name="roleIds"></param>
        void AddRoles(string id, IList<string> roleIds);
        /// <summary>
        /// Remove role
        /// </summary>
        /// <param name="id"></param>
        void DeleteRoles(string id);
    }
}
