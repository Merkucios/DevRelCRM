using DevRelCRM.Core.Constants;
using DevRelCRM.Application.Mappings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using DevRelCRM.Core.DomainServices;
using DevRelCRM.Core.Interfaces.Repositories;
using DevRelCRM.Core.Interfaces.Services;
using DevRelCRM.Infrastructure.Database.PostgreSQL.Repositories;
using DevRelCRM.Infrastructure.Database.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using DevRelCRM.Application.Users.Queries;
using DevRelCRM.Application.Users.Commands.CreateUser;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using DevRelCRM.Application.Users.Commands.LoginUser;
using DevRelCRM.Infrastructure.Security;

namespace DevRelCRM.WebAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();
            builder.AddRedisOutputCache("cache");

            // Получаем настройки JWT из конфигурации
            var jwtIssuer = builder.Configuration["JwtSettings:Issuer"];
            var jwtAudience = builder.Configuration["JwtSettings:Audience"];
            var jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"];

            // Dependency Injecttion AutoMapper
            builder.Services.AddAutoMapper(config =>
            {
                // Добавление профилей маппинга из сборок приложения
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(ApplicationDbContext).Assembly));
                config.AddProfile(new AssemblyMappingProfile(typeof(UserDetailsVm).Assembly));
            });

            // Добавляем сервисы для Razor Pages
            builder.Services.AddRazorPages();

            // Dependency Injection для Entity Framework с использованием PostgreSQL
            builder.Services.AddDbContext<ApplicationDbContext>(
                o => o.UseNpgsql(builder.Configuration.GetConnectionString("DevRelCRM_DB")));


            // Dependency Injecttion MediatR
            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(AssemblyMappingProfile).Assembly));

            // Dependency Injection для репозитория и сервиса пользователя
            builder.Services.AddScoped<IUserRepository, SQLUserRepository>();
            builder.Services.AddScoped<IUserService, UserService>();

            builder.Services.AddTransient<JwtTokenGenerator>();
            builder.Services.AddTransient<IValidator<CreateUserCommand>, CreateUserCommandValidator>();
            builder.Services.AddTransient<IValidator<LoginUserCommand>, LoginUserCommandValidator>();

            builder.Services.AddRazorPages().AddMvcOptions(options =>
            {
                options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            });

            // Конфигурируем аутентификацию: используем аутентификацию по куки и JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddJwtBearer(options =>
            {
                // Настройки проверки токена JWT
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecretKey))
                };
            });

            // Добавляем политики авторизации для ролей приложения
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy($"{nameof(Roles.Programmer)}Policy", policy => policy.RequireRole(nameof(Roles.Programmer)));
                options.AddPolicy($"{nameof(Roles.DevRel)}Policy", policy => policy.RequireRole(nameof(Roles.DevRel)));
                options.AddPolicy($"{nameof(Roles.Administrator)}Policy", policy => policy.RequireRole(nameof(Roles.Administrator)));
            });

            var app = builder.Build();

            app.MapDefaultEndpoints();

            // Конфигурируем конвейер HTTP-запросов
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // Значение HSTS по умолчанию — 30 дней. Можно изменить для продакшн версии https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapRazorPages();

            app.Run();
        }
    }
}
