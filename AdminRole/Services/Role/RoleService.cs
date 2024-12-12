using AdminRole.Dtos;
using AdminRole.Repositories.Role;
using AdminRole.SQLUnitOfWork;
using Mapster;
using AdminRole.Models;

namespace AdminRole.Services.Role
{
    public class RoleService: IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        private readonly IUnitOfWork _unitOfWork;
        public RoleService(IRoleRepository roleRepository, IUnitOfWork unitOfWork)
        {
            _roleRepository = roleRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<RoleDto> CreateAsync(CreateRoleDto createRoleDto)
        {
            var roleEntity = _roleRepository.Create(createRoleDto);
            _unitOfWork.Commit();
            var roleDto = roleEntity.Adapt<RoleDto>();
            return roleDto;
        }

        public async Task<RoleDto> GetByIdAsync(Guid id)
        {
            var roleEntity = _roleRepository.GetById(id);
            var roleDto = roleEntity.Adapt<RoleDto>();
            return roleDto;
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var roleList = _roleRepository.GetAll();
            var roleListDto = roleList.Select(role => role.Adapt<RoleDto>()).ToList();
            return roleListDto;
        }

        public async Task<RoleDto> UpdateAsync(UpdateRoleDto updateRoleDto)
        {
            var role = _roleRepository.Update(updateRoleDto);
            _unitOfWork.Commit();
            var roleDto = role.Adapt<RoleDto>();
            return roleDto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var isDeletedSuccessfully = _roleRepository.Delete(id);
            _unitOfWork.Commit();
            return isDeletedSuccessfully;
        }
    }
}
