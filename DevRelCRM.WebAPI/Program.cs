using DevRelCRM.Infrastructure.Database.PostgreSQL;
using DevRelCRM.Core.DomainModels;
using DevRelCRM.Core.Interfaces.Repositories;
using DevRelCRM.Infrastructure.Database.PostgreSQL.Repositories;
using DevRelCRM.Application.Mappings;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using DevRelCRM.Application;
using DevRelCRM.Application.Users.Queries;

namespace DevRelCRM.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "DevRelCRM.WebAPI", 
                    Version = "v1", 
                    Description = "RESTful API для взаимодействия клиентской части с серверной"}
            ));


            // Dependency Injecttion EF.PostgreSQL
            builder.Services.AddDbContext<ApplicationDbContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("DevRelCRM_DB")));


            // Dependency Injecttion AutoMapper
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ApplicationDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(UserDetailsVm).Assembly));
            });


            // Dependency Injecttion MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyMappingProfile).Assembly));

            // Dependency Injecttion
            builder.Services.AddScoped<IUserRepository, SQLUserRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevRelCRM.WebAPI v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
