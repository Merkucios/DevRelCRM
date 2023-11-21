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

namespace DevRelCRM.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // ���������� ������������
            builder.Services.AddControllers();

            // ���������� ��������� API Explorer ��� Endpoints
            builder.Services.AddEndpointsApiExplorer();

            // ���������� ��������� Swagger ��� ������������ API
            builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "DevRelCRM.WebAPI", 
                    Version = "v1", 
                    Description = "RESTful API ��� �������������� ���������� ����� � ���������"}
            ));


            // Dependency Injection ��� Entity Framework � �������������� PostgreSQL
            builder.Services.AddDbContext<ApplicationDbContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("DevRelCRM_DB")));


            // Dependency Injecttion AutoMapper
            builder.Services.AddAutoMapper(config =>
            {
                // ���������� �������� �������� �� ������ ����������
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ApplicationDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(UserDetailsVm).Assembly));
            });


            // Dependency Injecttion MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyMappingProfile).Assembly));

            // Dependency Injection ��� ����������� � ������� ������������
            builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // ��������� Swagger � ������ ����������
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevRelCRM.WebAPI v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            // ��������� HTTPS-���������������  
            app.UseHttpsRedirection();

            // ��������� �����������
            app.UseAuthorization();

            // ������������ ��������� ��� ������������
            app.MapControllers();

            app.Run();
        }
    }
}
