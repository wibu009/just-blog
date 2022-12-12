using AutoMapper;
using JustBlog.Repositories.Infrastructure;
using JustBlog.ViewModels.Role;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace JustBlog.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<RoleService> _logger;
        public RoleService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<RoleService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public bool Add(RoleToCreateViewModel roleToCreate)
        {
            try
            {
                var newRole = _mapper.Map<IdentityRole>(roleToCreate);
                newRole.Id = Guid.NewGuid().ToString();
                newRole.NormalizedName = roleToCreate.Name.ToUpper();
                _unitOfWork.RoleRepository.Insert(newRole);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public bool Update(RoleViewModel role)
        {
            try
            {
                var newRole = _mapper.Map<IdentityRole>(role);
                _unitOfWork.RoleRepository.Update(newRole);
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
                var deleteRole = _unitOfWork.RoleRepository.FindByCondition(r => r.Id == id);
                _unitOfWork.RoleRepository.Delete(deleteRole);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return false;
            }
        }

        public IList<RoleViewModel> GetAllRoles()
        {
            try
            {
                return _unitOfWork.RoleRepository.GetAll().Select(r => _mapper.Map<RoleViewModel>(r)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public IList<RoleViewModel> GetPagedRoles(int page, int pageSize)
        {
            try
            {
                var roles = _unitOfWork.RoleRepository.GetPagedItems(page, pageSize);

                return roles.Select(r => _mapper.Map<RoleViewModel>(r)).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return null!;
            }
        }

        public RoleViewModel GetDetailOfRoles(string id)
        {
            try
            {
                var role = _unitOfWork.RoleRepository.FindByCondition(r => r.Id == id);
                return _mapper.Map<RoleViewModel>(role);
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
                return _unitOfWork.RoleRepository.CountAll();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                return 0;
            }
        }
    }
}
