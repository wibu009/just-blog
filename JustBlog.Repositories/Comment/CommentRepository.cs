using JustBlog.Core.Database;
using JustBlog.Core.Entities;
using JustBlog.Repositories.Infrastructure;

namespace JustBlog.Repositories.Comment
{
    public class CommentRepository : GenericRepository<Core.Entities.Comment>, ICommentRepository
    {
        public CommentRepository(JustBlogContext context) : base(context) { }

        public IList<Core.Entities.Comment> GetCommentsForPost(int postId)
        {
            var c = Context.Comments!.ToList();
            return Context.Comments!.Where(c => c.PostId == postId).ToList();
        }
        public IList<Core.Entities.Comment> GetCommentsForPost(Core.Entities.Post post)
        {
            return Context.Comments!.Where(c => c.PostId == post.Id).ToList();
        }

        public void Add(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Core.Entities.Comment()
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };
            Context.Comments!.Add(comment);
        }
    }
}
