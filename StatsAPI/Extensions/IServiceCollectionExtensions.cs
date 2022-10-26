namespace StatsAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddScoped<IStatsService, StatsService>();
            services.AddSingleton<IMongoService, MongoService>();
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<LoggingMiddleware>();
        }
    }
}
