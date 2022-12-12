using AutoMapper;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Comment;
using Microsoft.Extensions.Logging;

namespace JustBlog.Services.Comment
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        public CommentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CommentService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<CommentViewModel> GetCommentsByPost(int postId)
        {
            try
            {
                var comments = _unitOfWork.CommentRepository.GetCommentsForPost(postId);
                return comments.OrderByDescending(c => c.CommentTime).Select(c => _mapper.Map<CommentViewModel>(c)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
        public bool Add(CommentToCreateViewModel commentToCreate)
        {
            try
            {
                _unitOfWork.CommentRepository.Add(commentToCreate.PostId, commentToCreate.Name, commentToCreate.Email, commentToCreate.CommentHeader, commentToCreate.CommentText);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public IList<CommentViewModel> GetPagedComments(int page, int pageSize)
        {
            try
            {
                return _unitOfWork.CommentRepository.GetPagedItems(page, pageSize).Select(c => _mapper.Map<CommentViewModel>(c)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public int CountAllComments()
        {
            try
            {
                return _unitOfWork.CommentRepository.CountAll();
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
                _unitOfWork.CommentRepository.DeleteById(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public CommentToUpdateViewModel GetCommentToUpdate(int id)
        {
            try
            {
                return _mapper.Map<CommentToUpdateViewModel>(_unitOfWork.CommentRepository.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public bool Update(CommentToUpdateViewModel commentToUpdate)
        {

            try
            {
                var comment = _mapper.Map<Core.Entities.Comment>(commentToUpdate);
                _unitOfWork.CommentRepository.Update(comment);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public CommentDetailsViewModel GetDetails(int id)
        {
            try
            {
                return _mapper.Map<CommentDetailsViewModel>(_unitOfWork.CommentRepository.GetById(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
    }
}
