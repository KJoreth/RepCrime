namespace CrimeAPI.Services.Interfaces
{
    public interface IRabbitMqSennder
    {
        void PublishMessage(string message);
    }
}