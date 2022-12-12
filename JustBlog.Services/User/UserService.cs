using AutoMapper;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Role;
using JustBlog.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace JustBlog.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public bool Add(NewUserViewModel user)
        {
            try
            {
                var newUser = _mapper.Map<Core.Entities.User>(user);
                newUser.EmailConfirmed = true;
                var hasher = new PasswordHasher<Core.Entities.User>();
                newUser.PasswordHash = hasher.HashPassword(newUser, user.Password);
                newUser.NormalizedEmail = newUser.Email.ToUpper();
                newUser.NormalizedUserName = newUser.UserName.ToUpper();
                _unitOfWork.UserRepository.Insert(newUser);
                _unitOfWork.Save();
                _unitOfWork.UserRepository.AddRoles(newUser.Id, user.Roles);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }
        public bool Update(EditUserViewModel editUser)
        {
            try
            {
                var user = _unitOfWork.UserRepository.FindByCondition(u => u.Id == editUser.Id);
                user.NormalizedEmail = editUser.Email.ToUpper();
                user.NormalizedUserName = editUser.UserName.ToUpper();
                _unitOfWork.UserRepository.Update(user);
                _unitOfWork.UserRepository.DeleteRoles(user.Id);
                _unitOfWork.UserRepository.AddRoles(user.Id, editUser.RoleIds);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }
        public bool Delete(string id)
        {
            try
            {
                var user = _unitOfWork.UserRepository.FindByCondition(u => u.Id == id);
                _unitOfWork.UserRepository.Delete(user);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }
        public IList<UserViewModel> GetAll()
        {
            try
            {
                return _unitOfWork.UserRepository.GetAll().Select(u => _mapper.Map<UserViewModel>(u)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
        public IList<UserViewModel> GetPagedUsers(int page, int pageSize)
        {
            try
            {
                return _unitOfWork.UserRepository.GetPagedItems(page, pageSize).Select(u => _mapper.Map<UserViewModel>(u)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }
        public UserDetailsViewModel GetDetails(string id)
        {
            try
            {
                var user = _unitOfWork.UserRepository.FindByCondition(u => u.Id == id);

                var userDetails = _mapper.Map<UserDetailsViewModel>(user);

                var roles = _unitOfWork.UserRepository.GetRoles(id);

                userDetails.Roles = roles.Select(r => _mapper.Map<RoleViewModel>(r)).ToList();

                return userDetails;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public EditUserViewModel GetEditUser(string id)
        {
            try
            {
                var user = _mapper.Map<EditUserViewModel>(GetDetails(id));
                return user;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public int CountAll()
        {
            try
            {
                return _unitOfWork.UserRepository.CountAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return 0;
            }
        }
    }
}
