using RabbitMQ.Client;

namespace RepCrime.Common.Services.Interfaces
{
    public interface IRabbitMqConnector
    {
        IModel? EstablishChanel(string queue, IConnection connection);
        IConnection? EstablishConnection();
    }
}