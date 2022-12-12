using JustBlog.ViewModels.Tag;

namespace JustBlog.Services.Tag
{
    public interface ITagService
    {
        IList<TagViewModel> GetTopTags(int size);
        IList<TagViewModel> GetPagedTags(int page, int pageSize);
        int CountAllTags();
        bool Delete(int id);
        bool Add(TagToCreateViewModel tagToCreate);
        IList<TagViewModel> GetAllTags();
        TagToUpdateViewModel GetTagToUpdate(int id);
        bool Update(TagToUpdateViewModel tagToUpdate);
        TagDetailsViewModel GetDetailOfTags(int id);
    }
}
