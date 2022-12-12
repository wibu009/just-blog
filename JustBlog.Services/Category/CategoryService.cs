using AutoMapper;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Category;
using Microsoft.Extensions.Logging;

namespace JustBlog.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CategoryService> _logger;
        public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CategoryService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<CategoryViewModel> GetAllCategories()
        {
            try
            {
                return _unitOfWork.CategoryRepository.GetAll().Select(c => _mapper.Map<CategoryViewModel>(c)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public IList<CategoryViewModel> GetPagedCategories(int page, int pageSize)
        {
            try
            {
                return _unitOfWork.CategoryRepository.GetPagedItems(page, pageSize).Select(c => _mapper.Map<CategoryViewModel>(c)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
        public int CountCategories()
        {
            try
            {
                return _unitOfWork.CategoryRepository.CountAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return 0;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                _unitOfWork.CategoryRepository.DeleteById(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public bool Add(CategoryToCreateViewModel categoryToCreate)
        {
            var category = _mapper.Map<Core.Entities.Category>(categoryToCreate);
            try
            {
                _unitOfWork.CategoryRepository.Insert(category);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public CategoryToUpdateViewModel GetCategoryToUpdateById(int id)
        {
            try
            {
                return _mapper.Map<CategoryToUpdateViewModel>(_unitOfWork.CategoryRepository.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public bool Update(CategoryToUpdateViewModel categoryToUpdate)
        {
            var category = _mapper.Map<Core.Entities.Category>(categoryToUpdate);
            try
            {
                _unitOfWork.CategoryRepository.Update(category);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public CategoryDetailsViewModel GetDetails(int id)
        {
            try
            {
                return _mapper.Map<CategoryDetailsViewModel>(_unitOfWork.CategoryRepository.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
    }
}
