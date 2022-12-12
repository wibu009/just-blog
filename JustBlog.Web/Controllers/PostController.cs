using JustBlog.Services.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET: PostController
        public IActionResult Index()
        {
            var posts = _postService.GetAllPostsWithCategoryAndTags();
            return View(posts);
        }

        public IActionResult AboutCard()
        {
            return PartialView("Component/_AboutCardPartial");
        }

        [ActionName("Latest")]
        public IActionResult LatestPost()
        {
            int size = 5;
            var posts = _postService.GetLatestPosts(size);
            return View(posts);
        }

        public IActionResult LatestPosts()
        {
            int size = 5;
            var posts = _postService.GetLatestPosts(size);
            return PartialView("Component/_ListPostsPartial", posts);
        }
        public IActionResult MostViewedPosts()
        {
            int size = 5;
            var posts = _postService.GetMostViewedPosts(size);
            return PartialView("Component/_ListPostsPartial", posts);
        }

        [Route("post/{year}/{month}/{slug}")]
        public IActionResult Details(int year, int month, string slug)
        {
            var post = _postService.GetDetailOfPosts(year, month, slug);
            if (post == null)
                return View("NotFound");
            return View(post);
        }
    }
}
