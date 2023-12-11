using Aspire.Hosting.Lifecycle;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

internal static class NodeAppHostingExtension
{
    public static IResourceBuilder<NextAppResource> AddNodeApp(this IDistributedApplicationBuilder builder, string name, string command, string workingDirectory, string[]? args = null)
    {
        var resource = new NextAppResource(name, command, workingDirectory, args);

        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IDistributedApplicationLifecycleHook, NextAppAddPortLifecycleHook>());

        return builder.AddResource(resource)
            .WithOtlpExporter()
            .WithEnvironment("NODE_ENV", builder.Environment.IsDevelopment() ? "development" : "production")
            .ExcludeFromManifest();
    }

    public static IResourceBuilder<NextAppResource> AddNpmApp(this IDistributedApplicationBuilder builder, string name, string workingDirectory, string scriptName = "dev")
        => builder.AddNodeApp(name, "npm", workingDirectory, ["run", scriptName]);
}