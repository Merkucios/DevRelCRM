using DevRelCRM.Infrastructure.Database.MongoDB.Habr.Services;
using DevRelCRM.Infrastructure.Database.MongoDB.Habr;
using MongoDB.Driver;
using Serilog;
using DevRelCRM.Infrastructure.Database.MongoDB;

namespace DevRelCRM.ParsersAPI
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

            string MongoDB_Connection = builder.Configuration.GetConnectionString("DevRelCRM_MongoDB");

            builder.AddServiceDefaults();

            // Add services to the container.

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

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            var MongoSingletion = builder.Services.AddSingleton<IMongoClient>(
                new MongoClient(MongoDB_Connection));

            builder.Services.AddScoped<IMongoSaveService, MongoDbSaveService>();


            var app = builder.Build();

            app.MapDefaultEndpoints();

            // Configure the HTTP request pipeline.
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
