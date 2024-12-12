using AdminRole.Helper;
using AdminRole.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

namespace AdminRole
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        public static void ConfigureServices(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            builder.Services.AddDbContext<AdminRoleContext> (options =>
            options.UseSqlServer(connectionString))
                .AddCors(o => o.AddPolicy("CorsPolicy", builder => {
                    builder
                    .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }))
                .SwaggerConfigureServices("Admin Role Apis", "Admin Role Apis", "v1")
                .DIConfigureServices()
                .Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true)
                ;
            builder.Services.AddDataProtection();
            builder.Services.AddHttpClient();
            builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseResponseCompression();
            app.UseCors("CorsPolicy");
            app.UseOpenApi();
            app.UseSwaggerUi(options =>
            {

            });
            app.UseReDoc();
            app.MapControllers();
            app.Run();
        }
    }
}
