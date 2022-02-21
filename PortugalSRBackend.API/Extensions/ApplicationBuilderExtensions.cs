using PortugalSRBackend.API.Middleware;

namespace PortugalSRBackend.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void AddApplicationConfiguration(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
        }
    }
}
