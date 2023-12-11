using DevRelCRM.Infrastructure.Services.SMTPService;
using Microsoft.AspNetCore.Http.Features;
using Serilog;
using Serilog.Events;

namespace DevRelCRM.WebNotifications
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .CreateLogger();

            var builder = WebApplication.CreateBuilder(args);
            builder.AddServiceDefaults();


            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.Configure<MailSettings>(builder.Configuration.GetSection(nameof(MailSettings)));
            builder.Services.AddTransient<IEmailService, EmailService>();

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("Policy", builder =>
                {
                    builder
                    .WithOrigins("http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            builder.Services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
            });

            var app = builder.Build();

            app.MapDefaultEndpoints();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseCors("Policy");

            app.MapControllers();

            app.Run();
        }
    }
}
