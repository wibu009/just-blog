using JustBlog.Services.Role;
using JustBlog.Services.User;
using JustBlog.ViewModels.Others;
using JustBlog.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

        public UserController(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;
        }

        [Authorize(policy: "Get")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(policy: "Get")]
        public IActionResult GetPagedUsers(int page, int pageSize)
        {
            var users = _userService.GetPagedUsers(page, pageSize);
            var total = _userService.CountAll();
            var lastPage = (int)Math.Ceiling((double)total / pageSize);
            var dataTable = new DataTableViewModel
            {
                Controller = "User",
                Action = "GetPagedUsers",
                Page = page,
                PageSize = pageSize,
                Total = total,
                LastPage = lastPage,
                Columns = new string[] { "Id", "User name", "Username", "Username confirm" },
                Data = users.Select(u => new Dictionary<string, string>
                {
                    { "Id", u.Id },
                    { "User name", u.UserName},
                    { "Username", u.Email},
                    { "Username confirm", u.EmailConfirm?"yes":"no"}
                }).ToList()
            };
            return PartialView("_DataTablePartial", dataTable);
        }

        [Authorize(policy: "Get")]
        public IActionResult Details(string id)
        {
            var user = _userService.GetDetails(id);
            if (user == null)
                return View("NotFound");
            return View(user);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Create()
        {
            ViewBag.Roles = _roleService.GetAllRoles();
            return View();
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Create(NewUserViewModel newUser)
        {
            if (ModelState.IsValid && _userService.Add(newUser))
            {
                return View("Index");
            }
            ViewBag.Roles = _roleService.GetAllRoles();
            return View(newUser);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Edit(string id)
        {
            ViewBag.Roles = _roleService.GetAllRoles();
            var user = _userService.GetEditUser(id);
            if (user == null)
                return View("NotFound");
            return View(user);
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Edit(EditUserViewModel editUser)
        {
            if (ModelState.IsValid)
            {
                if (_userService.Update(editUser))
                    ViewBag.Message = "Update Successfully!";
                else
                    ViewBag.Message = "Update failed!";
            }

            ViewBag.Roles = _roleService.GetAllRoles();
            return View(editUser);
        }

        [Authorize(policy: "Delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (_userService.Delete(id))
                return StatusCode(200);
            return View("NotFound");
        }
    }
}
