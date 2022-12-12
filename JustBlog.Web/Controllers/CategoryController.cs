using JustBlog.Services.Category;
using JustBlog.Services.Post;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IPostService _postService;
        public CategoryController(ICategoryService categoryService, IPostService postService)
        {
            _categoryService = categoryService;
            _postService = postService;
        }

        [Route("category/partialview/categoriesDropdown")]
        public IActionResult CategoriesDropDown()
        {
            var categories = _categoryService.GetAllCategories();
            return PartialView("Component/_CategoriesDropDownPartial", categories);
        }

        [Route("category/{slug}")]
        public ActionResult Details(string slug)
        {
            var posts = _postService.GetPostsByCategory(slug);
            return View("~/Views/Post/Index.cshtml", posts);
        }
    }
}
