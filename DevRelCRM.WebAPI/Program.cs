using DevRelCRM.Infrastructure.Database.PostgreSQL;
using DevRelCRM.Core.Interfaces.Repositories;
using DevRelCRM.Infrastructure.Database.PostgreSQL.Repositories;
using DevRelCRM.Application.Mappings;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DevRelCRM.Application.Users.Queries;
using DevRelCRM.Core.Interfaces.Services;
using DevRelCRM.Core.DomainServices;
using DevRelCRM.Infrastructure.Security;

namespace DevRelCRM.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();

            // Добавление контроллеров
            builder.Services.AddControllers();

            // Добавление поддержки API Explorer для Endpoints
            builder.Services.AddEndpointsApiExplorer();

            // Добавление поддержки Swagger для документации API
            builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "DevRelCRM.WebAPI", 
                    Version = "v1", 
                    Description = "RESTful API для взаимодействия клиентской части с серверной"}
            ));


            // Dependency Injection для Entity Framework с использованием PostgreSQL
            builder.Services.AddDbContext<ApplicationDbContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("DevRelCRM_DB")));


            // Dependency Injecttion AutoMapper
            builder.Services.AddAutoMapper(config =>
            {
                // Добавление профилей маппинга из сборок приложения
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ApplicationDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(UserDetailsVm).Assembly));
            });


            // Dependency Injecttion MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyMappingProfile).Assembly));

            // Dependency Injection для репозитория и сервиса пользователя
            builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddTransient<JwtTokenGenerator>();
            var app = builder.Build();

            app.MapDefaultEndpoints();

            // Включение Swagger в режиме разработки
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevRelCRM.WebAPI v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            // Включение HTTPS-перенаправления  
            app.UseHttpsRedirection();

            // Включение авторизации
            app.UseAuthorization();

            // Конфигурация маршрутов для контроллеров
            app.MapControllers();

            app.Run();
        }
    }
}
