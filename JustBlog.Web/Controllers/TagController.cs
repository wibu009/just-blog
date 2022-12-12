using JustBlog.Services.Post;
using JustBlog.Services.Tag;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService _tagService;
        private readonly IPostService _postService;
        public TagController(ITagService tagService, IPostService postService)
        {
            _tagService = tagService;
            _postService = postService;
        }

        [Route("tag/partialview/populartags")]
        public IActionResult PopularTags()
        {
            int size = 5;
            var tags = _tagService.GetTopTags(size);
            return PartialView("Component/_PopularTagsPartial", tags);
        }

        [Route("tag/{slug}")]
        public IActionResult Details(string slug)
        {
            var posts = _postService.GetPostsByTag(slug);
            return View("~/Views/Post/Index.cshtml", posts);
        }
    }
}
