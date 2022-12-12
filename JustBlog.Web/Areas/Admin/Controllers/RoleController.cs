using JustBlog.Services.Role;
using JustBlog.ViewModels.Others;
using JustBlog.ViewModels.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRoleService _roleService;
        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [Authorize(policy: "Get")]
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(policy: "Get")]
        public IActionResult GetPagedRoles(int page, int pageSize)
        {
            var roles = _roleService.GetPagedRoles(page, pageSize);
            var total = _roleService.CountAll();
            var lastePage = (int)Math.Ceiling((double)total / pageSize);
            var dataTable = new DataTableViewModel
            {
                Controller = "Role",
                Action = "GetPagedRoles",
                Columns = new string[] { "Id", "Name", "ConcurrencyStamp" },
                Page = page,
                PageSize = pageSize,
                Total = total,
                LastPage = lastePage,
                Data = roles.Select(r => new Dictionary<string, string>
                {
                    { "Id", r.Id },
                    { "Name", r.Name },
                    { "ConcurrencyStamp", r.ConcurrencyStamp }
                }).ToList()
            };
            return PartialView("_DataTablePartial", dataTable);
        }


        [Authorize(policy: "Get")]
        public IActionResult Details(string id)
        {
            var role = _roleService.GetDetailOfRoles(id);
            if (role == null)
                return View("NotFound");
            return View(role);

        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Create(RoleToCreateViewModel roleToCreate)
        {
            if (ModelState.IsValid && _roleService.Add(roleToCreate))
            {
                return Redirect("/Admin/Role");
            }
            return View(roleToCreate);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Edit(string id)
        {
            var role = _roleService.GetDetailOfRoles(id);
            if (role == null)
                return View("NotFound");
            return View(role);
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Edit(RoleViewModel role)
        {
            if (ModelState.IsValid)
            {
                if (_roleService.Update(role))
                    ViewBag.Message = "Update successfully";
                else
                    ViewBag.Message = "Update failed";
            }
            return View(role);
        }

        [Authorize(policy: "Delete")]
        [HttpDelete]
        public IActionResult Delete(string id)
        {
            if (_roleService.Delete(id))
                return StatusCode(200);
            return View("NotFound");
        }
    }
}
