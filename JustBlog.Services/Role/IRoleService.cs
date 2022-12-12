using JustBlog.ViewModels.Role;

namespace JustBlog.Services.Role
{
    public interface IRoleService
    {
        bool Add(RoleToCreateViewModel roleToCreate);
        bool Update(RoleViewModel role);
        bool Delete(string id);
        IList<RoleViewModel> GetAllRoles();
        IList<RoleViewModel> GetPagedRoles(int page, int pageSize);
        RoleViewModel GetDetailOfRoles(string id);
        int CountAll();
    }
}
