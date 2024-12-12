using AdminRole.Dtos;
using Mapster;

namespace AdminRole.Helper.Mapping
{
    public class AdminRoleMapster : IMapper
    {
        public void Configure()
        {
            var role = TypeAdapterConfig<Models.Role, RoleDto>.NewConfig();
            var admin = TypeAdapterConfig<Models.Admin, AdminDto>.NewConfig().Map(dest => dest.RoleName, src => src.Role.Name);

            role.Compile();
            admin.Compile();
        }
    }
}
