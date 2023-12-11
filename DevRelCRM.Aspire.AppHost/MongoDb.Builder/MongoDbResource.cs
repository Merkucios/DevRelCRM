namespace DevRelCRM.Aspire.AppHost.MongoDb.Builder
{
    internal class MongoDbResource(string name, string password) : ContainerResource(name), IResourceWithConnectionString
    {
        public string Password { get; } = password;

        public string? GetConnectionString()
        {
            if (!this.TryGetAnnotationsOfType<AllocatedEndpointAnnotation>(out var allocatedEndpoints))
            {
                throw new DistributedApplicationException("Expected allocated endpoints!");
            }

            var endpoint = allocatedEndpoints.Single();

            return $"mongodb://host.docker.internal:{endpoint.Port}";
        }
    }
}
