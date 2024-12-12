using AdminRole.Dtos;

namespace AdminRole.Services.Role
{
    public interface IRoleService
    {
        Task<RoleDto> CreateAsync(CreateRoleDto createRoleDto);
        Task<RoleDto> GetByIdAsync(Guid id);
        Task<List<RoleDto>> GetAllAsync();
        Task<RoleDto> UpdateAsync(UpdateRoleDto updateRoleDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
