using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels;
using JustBlog.ViewModels.Comment;
using JustBlog.Common;
using JustBlog.Services.Comment;
using JustBlog.Services.Post;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using JustBlog.ViewModels.Others;
using Microsoft.AspNetCore.Authorization;

namespace JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly IPostService _postService;
        public CommentController(ICommentService commentService, IPostService postService)
        {
            _commentService = commentService;
            _postService = postService;
        }

        [Authorize(policy: "Get")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(policy: "Get")]
        public IActionResult GetPagedComments(int page, int pageSize)
        {
            var comments = _commentService.GetPagedComments(page, pageSize);
            var total = _commentService.CountAllComments();
            var dataTable = new DataTableViewModel
            {
                Action = "GetPagedComments",
                Controller = "Comment",
                Total = total,
                Page = page,
                LastPage = (int)Math.Ceiling((double)total / pageSize),
                PageSize = pageSize,
                Columns = new string[] { "Id", "Comment header", "Name", "Username", "Posted at" },
                Data = comments.Select(comment =>
                    new Dictionary<string, string>
                    {
                        { "Id", comment.Id.ToString() },
                        { "Comment header", comment.CommentHeader.ToString() },
                        { "Name", comment.Name },
                        { "Username", comment.Email },
                        { "Posted at", comment.CommentTime.FriendlyFormat() }
                    }
                ).ToList()
            };
            return PartialView("_DataTablePartial", dataTable);
        }

        [Authorize(policy: "Get")]
        public IActionResult Details(int id)
        {
            var commentDetails = _commentService.GetDetails(id);
            return View(commentDetails);
        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Create()
        {
            ViewBag.Posts = _postService.GetAllPosts();
            return View();
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Create(CommentToCreateViewModel commentToCreate)
        {
            if (ModelState.IsValid && _commentService.Add(commentToCreate))
                return Redirect("/Admin/Comment");
            ViewBag.Posts = _postService.GetAllPosts();
            return View(commentToCreate);

        }

        [Authorize(policy: "Create Or Edit")]
        public IActionResult Edit(int id)
        {
            var editComment = _commentService.GetCommentToUpdate(id);
            if (editComment == null)
                return View("NotFound");

            ViewBag.Posts = _postService.GetAllPosts();
            return View(editComment);
        }

        [Authorize(policy: "Create Or Edit")]
        [HttpPost]
        public IActionResult Edit(CommentToUpdateViewModel commentToUpdate)
        {
            if (ModelState.IsValid)
            {
                if (_commentService.Update(commentToUpdate))
                    ViewBag.Message = "Update comment successfully";
                else
                    ViewBag.Message = "Update comment failed";
            }

            ViewBag.Posts = _postService.GetAllPosts();
            return View(commentToUpdate);
        }

        [Authorize(policy: "Delete")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (_commentService.Delete(id))
                return StatusCode(200);
            return View("NotFound");
        }
    }
}
