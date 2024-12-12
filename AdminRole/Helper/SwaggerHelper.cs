using NSwag;
using NSwag.Generation.Processors.Security;
namespace AdminRole.Helper
{
    public static class SwaggerHelper
    {
        public static IServiceCollection SwaggerConfigureServices(this IServiceCollection services, string title, string description, string version)
        {
            services.AddOpenApiDocument(document =>
            {
                document.DocumentName = title;
                document.Description = description;
                document.PostProcess = config =>
                {
                    config.Info.Title = title;
                    config.Info.Description = description;
                    config.Info.Version = version;
                };
                document.AddSecurity("JWT", Enumerable.Empty<string>(),
                    new NSwag.OpenApiSecurityScheme
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Type into the text box: Bearer {your JWT token}."
                    });

                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            });
            return services;
        }
    }
}
