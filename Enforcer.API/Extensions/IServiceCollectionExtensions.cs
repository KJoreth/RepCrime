namespace EnforcerAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IEnforcerRepository, EnforcerRepository>();
            services.AddScoped<ICrimeRepository, CrimeRepository>();
            services.AddScoped<IEnforcersService, EnforcersService>();
        }

        public static void AddCustomMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<LoggingMiddleware>();
        }
    }
}
