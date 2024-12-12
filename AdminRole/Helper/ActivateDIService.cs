using AdminRole.Helper.Mapping;
using AdminRole.Repositories.Admin;
using AdminRole.Repositories.Role;
using AdminRole.Services.Admin;
using AdminRole.Services.Role;
using AdminRole.SQLUnitOfWork;

namespace AdminRole.Helper
{
    public static class ActivateDIService
    {
        internal static IServiceCollection DIConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddMemoryCache();
            services.RegisterThirdParty();
            return services;
        }
        private static void RegisterThirdParty(this IServiceCollection services)
        {
            new AdminRoleMapster().Configure();
        }
    }
}
