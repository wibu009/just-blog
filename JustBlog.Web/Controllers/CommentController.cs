using JustBlog.Services.Comment;
using JustBlog.ViewModels.Comment;
using Microsoft.AspNetCore.Mvc;

namespace JustBlog.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult CommentsByPosts(int id)
        {
            var comments = _commentService.GetCommentsByPost(id);
            return PartialView("Component/_CommentListPartial", comments);
        }

        public IActionResult AddComment([FromBody] CommentToCreateViewModel commentToCreate)
        {
            _commentService.Add(commentToCreate);
            return StatusCode(201);
        }
    }
}
