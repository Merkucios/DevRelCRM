using DevRelCRM.Aspire.AppHost.MongoDb.Builder;

var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");
var rabbitmq = builder.AddRabbitMQConnection("MessageBroker");

//  POSTGRES_HOST_AUTH_METHOD has been set to "trust". Нужно заменить на безопасный вход Docker контейнера
    // Связать DbContext с Pgdb контейнера
var postgres = builder.AddPostgresContainer("postgres");
var authDb = postgres.AddDatabase("AuthDb");

var mongo = builder.AddMongoDBContainer("mongodb")
    .WithMongoExpress();

builder
    .AddNpmApp("NextFrontend", "../devrelcrm-webapp")
    .WithServiceBinding(scheme: "http", hostPort: 3000); 

builder
    .AddProject<Projects.DevRelCRM_WebAPI>("devrelcrm.webapi")
    .WithLaunchProfile("https");

builder
    .AddProject<Projects.DevRelCRM_WebAuth>("devrelcrm.webauth")
    .WithReference(cache)
    .WithLaunchProfile("https");

builder
    .AddProject<Projects.DevRelCRM_WebNotifications>("devrelcrm.webnotifications")
    .WithLaunchProfile("https");

builder.Build().Run();
