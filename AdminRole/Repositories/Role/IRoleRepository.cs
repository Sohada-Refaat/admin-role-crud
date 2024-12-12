using AdminRole.Dtos;

namespace AdminRole.Repositories.Role
{
    public interface IRoleRepository
    {
        Models.Role Create(CreateRoleDto createRoleDto);
        Models.Role GetById(Guid id);
        IQueryable<Models.Role> GetAll();
        Models.Role Update(UpdateRoleDto updateRoleDto);
        bool Delete(Guid id);
    }
}
