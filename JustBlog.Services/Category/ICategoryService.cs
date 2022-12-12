using JustBlog.ViewModels.Category;

namespace JustBlog.Services.Category
{
    public interface ICategoryService
    {
        IList<CategoryViewModel> GetAllCategories();
        IList<CategoryViewModel> GetPagedCategories(int page, int pageSize);
        int CountCategories();
        bool Delete(int id);
        bool Add(CategoryToCreateViewModel categoryToCreate);
        bool Update(CategoryToUpdateViewModel categoryToUpdate);
        CategoryToUpdateViewModel GetCategoryToUpdateById(int id);
        CategoryDetailsViewModel GetDetails(int id);
    }
}
