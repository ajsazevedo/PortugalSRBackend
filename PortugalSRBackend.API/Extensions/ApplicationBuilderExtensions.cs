namespace PortugalSRBackend.API.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void AddApplicationConfiguration(this IApplicationBuilder app)
        {
            // Configure the HTTP request pipeline.
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
        }
    }
}
