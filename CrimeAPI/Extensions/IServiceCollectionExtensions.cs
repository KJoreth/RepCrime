namespace CrimeAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddSingleton<IMongoService, MongoService>();
            services.AddScoped<ICrimesService, CrimesService>();
            services.AddSingleton<IRabbitMqConnector, RabbitMqConnector>();
            services.AddSingleton<IRabbitMqSennder, RabbitMqSennder>();
        }

        public static void AddCustomCors(this IServiceCollection services)
        {
            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));
        }

        public static void AddCustomMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<LoggingMiddleware>();
        }
    }
}
