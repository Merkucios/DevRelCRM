﻿using System.Globalization;
using System.Net.Sockets;
using System.Text.Json;


namespace DevRelCRM.Aspire.AppHost.MongoDb.Builder
{
    internal static class MongoDbExtension
    {
        public static IResourceBuilder<MongoDbResource> AddMongoDBContainer(this IDistributedApplicationBuilder builder, string name, string? password = null)
        {
            password = password ?? Guid.NewGuid().ToString("N");
            var mongo = new MongoDbResource(name, password);
            return builder.AddResource(mongo)
                          .WithAnnotation(new ManifestPublishingCallbackAnnotation(WriteMongoDBContainerToManifest))
                          .WithAnnotation(new ServiceBindingAnnotation(ProtocolType.Tcp, containerPort: 27017))
                          .WithAnnotation(new ContainerImageAnnotation { Image = "mongo", Tag = "latest" });
        }

        public static IResourceBuilder<MongoDbResource> WithMongoExpress(this IResourceBuilder<MongoDbResource> builder)
        {
            builder.ApplicationBuilder.AddContainer("mongo-express", "mongo-express", "latest")
                                      .WithServiceBinding(8081, 8081, scheme: "http")
                                      .WithAnnotation(ManifestPublishingCallbackAnnotation.Ignore)
                                      .WithEnvironment((context) =>
            {
                if (builder.Resource.GetConnectionString() is not { } connectionString)
                {
                    throw new DistributedApplicationException($"MongoDBContainer resource '{builder.Resource.Name}' did not return a connection string.");
                }
                var connectionStringUri = new Uri(connectionString);
                context.EnvironmentVariables.Add("ME_CONFIG_MONGODB_SERVER", connectionStringUri.Host);
                context.EnvironmentVariables.Add("ME_CONFIG_MONGODB_PORT", connectionStringUri.Port.ToString(CultureInfo.InvariantCulture));
            });

            return builder;
        }

        private static void WriteMongoDBContainerToManifest(Utf8JsonWriter jsonWriter)
        {
            jsonWriter.WriteString("type", "mongodb.server.v0");
        }

    }
}
