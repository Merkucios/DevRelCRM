using DevRelCRM.Core.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace DevRelCRM.WebAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // �������� ��������� JWT �� ������������
            var jwtIssuer = builder.Configuration["JwtSettings:Issuer"];
            var jwtAudience = builder.Configuration["JwtSettings:Audience"];
            var jwtSecretKey = builder.Configuration["JwtSettings:SecretKey"];

            // ��������� ������� ��� Razor Pages
            builder.Services.AddRazorPages();

            // ������������� ��������������: ���������� �������������� �� ���� � JWT
            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie()
            .AddJwtBearer(options =>
            {
                // ��������� �������� ������ JWT
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

            // ��������� �������� ����������� ��� ����� ����������
            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy($"{nameof(Roles.Programmer)}Policy", policy => policy.RequireRole(nameof(Roles.Programmer)));
                options.AddPolicy($"{nameof(Roles.DevRel)}Policy", policy => policy.RequireRole(nameof(Roles.DevRel)));
                options.AddPolicy($"{nameof(Roles.Administrator)}Policy", policy => policy.RequireRole(nameof(Roles.Administrator)));
            });

            var app = builder.Build();

            // ������������� �������� HTTP-��������
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // �������� HSTS �� ��������� � 30 ����. ����� �������� ��� �������� ������ https://aka.ms/aspnetcore-hsts.
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
