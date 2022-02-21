namespace PortugalSRBackend.API.Extensions
{
    public static class EndpointRouteBuilderExtensions
    {
        public static void AddEndpointConfiguration(this IEndpointRouteBuilder app)
        {
            // Configure the HTTP request pipeline.
            app.MapControllers();
        }
    }
}
