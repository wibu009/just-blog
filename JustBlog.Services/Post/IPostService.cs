using JustBlog.ViewModels.Post;

namespace JustBlog.Services.Post
{
    public interface IPostService
    {
        IList<PostViewModel> GetAllPosts();
        IList<PostViewModel> GetLatestPosts(int size);
        IList<PostViewModel> GetMostViewedPosts(int size);
        PostDetailsViewModel GetDetailOfPosts(int id);
        PostDetailsViewModel GetDetailOfPosts(int year, int month, string urlSlug);
        IList<PostViewModel> GetPostsByCategory(string urlSlug);
        IList<PostViewModel> GetPostsByTag(string urlSlug);
        IList<PostAdminViewModel> GetPagedPosts(int page, int pageSize);
        IList<PostViewModel> GetAllPostsWithCategoryAndTags();
        bool Delete(int id);
        bool Add(PostToCreateViewModel postToCreate);
        PostToUpdateViewModel GetPostToUpdate(int id);
        bool Update(PostToUpdateViewModel postToUpdate);
    }
}
