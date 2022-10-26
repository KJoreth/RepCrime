namespace RepCrimeEmailAPI.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
           services.AddSingleton<IEmailSender, EmailSender>();
           services.AddSingleton<IRabbitMqConnector, RabbitMqConnector>();
           services.AddHostedService<RabbitMqConsumer>();
        }
    }
}
