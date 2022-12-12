using AutoMapper;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Post;
using Microsoft.Extensions.Logging;

namespace JustBlog.Services.Post
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PostService> _logger;
        public PostService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PostService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public IList<PostViewModel> GetAllPosts()
        {
            try
            {
                return _unitOfWork.PostRepository.GetAll().Select(p => _mapper.Map<PostViewModel>(p)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public IList<PostViewModel> GetLatestPosts(int size)
        {
            try
            {
                return _unitOfWork.PostRepository.GetLatestPost(size).Select(p => _mapper.Map<PostViewModel>(p)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public IList<PostViewModel> GetMostViewedPosts(int size)
        {
            return _unitOfWork.PostRepository.GetMostViewedPosts(size).Select(p => _mapper.Map<PostViewModel>(p)).ToList();
        }

        public PostDetailsViewModel GetDetailOfPosts(int id)
        {
            try
            {
                return _mapper.Map<PostDetailsViewModel>(_unitOfWork.PostRepository.GetAllPostsWithCategoryAndTags().First(p => p.Id == id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public PostDetailsViewModel GetDetailOfPosts(int year, int month, string urlSlug)
        {
            try
            {
                var post = _unitOfWork.PostRepository.GetDetails(year, month, urlSlug);
                var postDetails = _mapper.Map<PostDetailsViewModel>(post);
                return postDetails;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public IList<PostViewModel> GetPostsByCategory(string urlSlug)
        {
            try
            {
                return _unitOfWork.PostRepository.GetPostsByCategory(urlSlug).Select(p => _mapper.Map<PostViewModel>(p)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public IList<PostViewModel> GetPostsByTag(string urlSlug)
        {
            try
            {
                return _unitOfWork.PostRepository.GetPostsByTag(urlSlug).Select(p => _mapper.Map<PostViewModel>(p)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public IList<PostAdminViewModel> GetPagedPosts(int page, int pageSize)
        {
            try
            {
                return _unitOfWork.PostRepository.GetPagedItems(page, pageSize).Select(p => _mapper.Map<PostAdminViewModel>(p)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
        public IList<PostViewModel> GetAllPostsWithCategoryAndTags()
        {
            return _unitOfWork.PostRepository.GetAllPostsWithCategoryAndTags().Select(p => _mapper.Map<PostViewModel>(p)).ToList();
        }
        public bool Delete(int id)
        {
            try
            {
                _unitOfWork.PostRepository.DeleteById(id);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }
        public bool Add(PostToCreateViewModel postToCreate)
        {
            var post = new Core.Entities.Post
            {
                CategoryId = postToCreate.CategoryId,
                PostContent = postToCreate.PostContent,
                PostedOn = DateTime.Now,
                ShortDescription = postToCreate.ShortDescription,
                UrlSlug = postToCreate.UrlSlug,
                Published = postToCreate.Published,
                Title = postToCreate.Title
            };
            try
            {
                _unitOfWork.PostRepository.Insert(post);
                _unitOfWork.Save();
                var postId = post.Id;

                _unitOfWork.PostRepository.AddTags(postId, postToCreate.TagIds);
                _unitOfWork.Save();

                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public PostToUpdateViewModel GetPostToUpdate(int id)
        {
            try
            {
                return _mapper.Map<PostToUpdateViewModel>(_unitOfWork.PostRepository.GetPostWithTags(id));
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public bool Update(PostToUpdateViewModel postToUpdate)
        {
            try
            {
                var post = _mapper.Map<Core.Entities.Post>(postToUpdate);
                post.Modified = DateTime.Now;
                _unitOfWork.PostRepository.Update(post);
                _unitOfWork.PostRepository.DeleteTags(postToUpdate.Id);
                _unitOfWork.PostRepository.AddTags(postToUpdate.Id, postToUpdate.TagIds);
                _unitOfWork.Save();
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }
    }
}
