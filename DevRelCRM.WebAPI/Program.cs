using DevRelCRM.WebAPI.Mappings;
using DevRelCRM.Infrastructure.Database.PostgreSQL;
using DevRelCRM.Core.Interfaces.Repositories;
using DevRelCRM.Infrastructure.Database.PostgreSQL.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

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

            builder.Services.AddDbContext<ApplicationDbContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("DevRelCRM_DB")));

            builder.Services.AddAutoMapper(typeof(AssemblyMappingProfile));


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
