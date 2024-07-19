namespace TrueCodeTest.Api.Extensions
{
    public static class CorsServices
    {
        public static void AddCorsServices(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("DefaultPolicy", builder =>
                {
                    builder.AllowAnyHeader();
                    builder.AllowAnyMethod();
                    builder.AllowAnyOrigin();
                });
            });
        }
    }
}
