using AdminRole.Dtos;
using AdminRole.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminRole.Repositories.Role
{
    public class RoleRepository : IRoleRepository
    {
        private readonly AdminRoleContext _dbContext;
        public RoleRepository(AdminRoleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Models.Role Create(CreateRoleDto createRoleDto)
        {
            var role = new Models.Role { Id = Guid.NewGuid(), Name = createRoleDto.Name };
            var entity = _dbContext.Roles.Add(role).Entity;
            return entity;
        }
        public Models.Role GetById(Guid id)
        {
            var entity = _dbContext.Roles.Include(role => role.Admins).SingleOrDefault(r => r.Id == id && !r.IsDeleted);
            return entity;
        }

        public IQueryable<Models.Role> GetAll()
        {
            var entities = _dbContext.Roles.Where(role => !role.IsDeleted);
            return entities;
        }
        public Models.Role Update(UpdateRoleDto updateRoleDto)
        {
            var role = GetById(updateRoleDto.Id);
            role.Name = updateRoleDto.Name;
            return role;
        }
        public bool Delete(Guid id)
        {
            var role = GetById(id);

            if (role != null)
            {
                role.IsDeleted = true;
                role.Admins.Select(admin => admin.RoleId = null).ToList();
                return true;
            }
            return false;
        }
    }
}
