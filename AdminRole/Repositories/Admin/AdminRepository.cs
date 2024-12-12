using AdminRole.Dtos;
using AdminRole.Models;
using Microsoft.EntityFrameworkCore;

namespace AdminRole.Repositories.Admin
{
    public class AdminRepository : IAdminRepository
    {
        private readonly AdminRoleContext _dbContext;
        public AdminRepository(AdminRoleContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Models.Admin Create(CreateAdminDto createAdminDto)
        {
            var admin = new Models.Admin { Id = Guid.NewGuid(), Name = createAdminDto.Name, Email = createAdminDto.Email, RoleId = createAdminDto.RoleId };
            var entity = _dbContext.Admins.Add(admin).Entity;
            return entity;
        }

        public bool Delete(Guid id)
        {
            var admin = GetById(id);
            if (admin != null)
            {
                admin.IsDeleted = true;
                return true;
            }
            return false;
        }

        public IQueryable<Models.Admin> GetAll()
        {
            var entities = _dbContext.Admins.Include(admin => admin.Role).Where(admin => !admin.IsDeleted);
            return entities;
        }

        public Models.Admin GetById(Guid id)
        {
            var entity = _dbContext.Admins.SingleOrDefault(r => r.Id == id && !r.IsDeleted);
            return entity;
        }

        public Models.Admin Update(UpdateAdminDto updateAdminDto)
        {
            var admin = GetById(updateAdminDto.Id);
            admin.Name = updateAdminDto.Name;
            admin.Email = updateAdminDto.Email;
            admin.RoleId = updateAdminDto.RoleId;
            return admin; 
        }
    }
}
