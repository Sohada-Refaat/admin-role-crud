using AdminRole.Dtos;

namespace AdminRole.Repositories.Admin
{
    public interface IAdminRepository
    {
        Models.Admin Create(CreateAdminDto createAdminDto);
        Models.Admin GetById(Guid id);
        IQueryable<Models.Admin> GetAll();
        Models.Admin Update(UpdateAdminDto updateAdminDto);
        bool Delete(Guid id);
    }
}
