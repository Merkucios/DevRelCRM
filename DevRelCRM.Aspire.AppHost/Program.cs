var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");
var rabbitmq = builder.AddRabbitMQConnection("MessageBroker");

//  POSTGRES_HOST_AUTH_METHOD has been set to "trust". ����� �������� �� ���������� ���� Docker ����������
    // ������� DbContext � Pgdb ����������
var postgres = builder.AddPostgresContainer("postgres");
var authDb = postgres.AddDatabase("AuthDb");

builder.
    AddNpmApp("NextFrontend", "../devrelcrm-webapp")
    .WithServiceBinding(scheme: "http", hostPort: 3000); ;

builder.
    AddProject<Projects.DevRelCRM_WebAPI>("devrelcrm.webapi")
    .WithLaunchProfile("https");

builder.
    AddProject<Projects.DevRelCRM_WebAuth>("devrelcrm.webauth")
    .WithReference(cache)
    .WithLaunchProfile("https");

builder.Build().Run();
