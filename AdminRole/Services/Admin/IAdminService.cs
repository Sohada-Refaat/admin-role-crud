using AdminRole.Dtos;

namespace AdminRole.Services.Admin
{
    public interface IAdminService
    {
        Task<AdminDto> CreateAsync(CreateAdminDto createAdminDto);
        Task<AdminDto> GetByIdAsync(Guid id);
        Task<List<AdminDto>> GetAllAsync();
        Task<AdminDto> UpdateAsync(UpdateAdminDto updateAdminDto);
        Task<bool> DeleteAsync(Guid id);
    }
}
