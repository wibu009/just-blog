using AutoMapper;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Tag;
using Microsoft.Extensions.Logging;

namespace JustBlog.Services.Tag
{
    public class TagService : ITagService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<TagService> _logger;
        public TagService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<TagService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public IList<TagViewModel> GetTopTags(int size)
        {
            try
            {
                return _unitOfWork.TagRepository.GetTopTags(size).Select(t => _mapper.Map<TagViewModel>(t)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
        public IList<TagViewModel> GetPagedTags(int page, int pageSize)
        {
            try
            {
                return _unitOfWork.TagRepository.GetPagedItems(page, pageSize).Select(t => _mapper.Map<TagViewModel>(t)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
        public IList<TagViewModel> GetAllTags()
        {
            try
            {
                return _unitOfWork.TagRepository.GetAll().Select(t => _mapper.Map<TagViewModel>(t)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
        public int CountAllTags()
        {
            try
            {
                return _unitOfWork.TagRepository.CountAll();
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
                _unitOfWork.TagRepository.DeleteById(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public bool Add(TagToCreateViewModel tagToCreate)
        {
            var tag = new Core.Entities.Tag
            {
                Name = tagToCreate.Name,
                Description = tagToCreate.Description,
                UrlSlug = tagToCreate.UrlSlug
            };
            try
            {
                _unitOfWork.TagRepository.Insert(tag);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public TagToUpdateViewModel GetTagToUpdate(int id)
        {
            try
            {
                return _mapper.Map<TagToUpdateViewModel>(_unitOfWork.TagRepository.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public bool Update(TagToUpdateViewModel tagToUpdate)
        {
            var tag = _mapper.Map<Core.Entities.Tag>(tagToUpdate);
            try
            {
                _unitOfWork.TagRepository.Update(tag);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }
        public TagDetailsViewModel GetDetailOfTags(int id)
        {
            try
            {
                return _mapper.Map<TagDetailsViewModel>(_unitOfWork.TagRepository.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
    }
}
