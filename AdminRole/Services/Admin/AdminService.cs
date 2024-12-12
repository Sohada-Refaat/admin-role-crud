using AdminRole.Dtos;
using AdminRole.Repositories.Admin;
using AdminRole.SQLUnitOfWork;
using Mapster;

namespace AdminRole.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IUnitOfWork _unitOfWork;
        public AdminService(IAdminRepository adminRepository, IUnitOfWork unitOfWork)
        {
            _adminRepository = adminRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<AdminDto> CreateAsync(CreateAdminDto createAdminDto)
        {
            var adminEntity = _adminRepository.Create(createAdminDto);
            _unitOfWork.Commit();
            var adminDto = adminEntity.Adapt<AdminDto>();
            return adminDto;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var isDeletedSuccessfully = _adminRepository.Delete(id);
            _unitOfWork.Commit();
            return isDeletedSuccessfully;
        }

        public async Task<List<AdminDto>> GetAllAsync()
        {
            var adminList = _adminRepository.GetAll();
            var adminListDto = adminList.Select(role => role.Adapt<AdminDto>()).ToList();
            return adminListDto;
        }

        public async Task<AdminDto> GetByIdAsync(Guid id)
        {
            var adminEntity = _adminRepository.GetById(id);
            var adminDto = adminEntity.Adapt<AdminDto>();
            return adminDto;
        }

        public async Task<AdminDto> UpdateAsync(UpdateAdminDto updateAdminDto)
        {
            var admin = _adminRepository.Update(updateAdminDto);
            _unitOfWork.Commit();
            var adminDto = admin.Adapt<AdminDto>();
            return adminDto;
        }
    }
}
