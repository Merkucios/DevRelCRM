var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");
//  POSTGRES_HOST_AUTH_METHOD has been set to "trust". Нужно заменить на безопасный вход Docker контейнера
    // Связать DbContext с Pgdb контейнера
var postgres = builder.AddPostgresContainer("postgres");
var authDb = postgres.AddDatabase("AuthDb");

builder.AddProject<Projects.DevRelCRM_WebAPI>("devrelcrm.webapi")
    .WithLaunchProfile("https");

builder.AddProject<Projects.DevRelCRM_WebAuth>("devrelcrm.webauth")
    .WithReference(cache)
    .WithLaunchProfile("https");

builder.Build().Run();
