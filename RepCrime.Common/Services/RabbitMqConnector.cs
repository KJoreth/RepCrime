using RabbitMQ.Client.Exceptions;

namespace RepCrime.Common.Services
{
    public class RabbitMqConnector : IRabbitMqConnector
    {
        private readonly IConfiguration _config;

        public RabbitMqConnector(IConfiguration config)
            => _config = config;

        public IConnection? EstablishConnection()
        {
            var factory = new ConnectionFactory()
            {
                HostName = _config["RabbitMqHost"],
                Port = int.Parse(_config["RabbitMqPort"]),
                VirtualHost = _config["RabbitMqVirtualHost"],
                UserName = _config["RabbitMqUsername"],
                Password = _config["RabbitMqPassword"]
            };

            try
            {
                var connection = factory.CreateConnection();
                return connection;
            }
            catch (BrokerUnreachableException e)
            {
                Console.WriteLine($"RabbitMQ server is unreachable: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Establishing a connection with RabbitMQ failed. Exception: {e.Message}");
                return null;
            }
        }

        public IModel? EstablishChanel(string queue, IConnection connection)
        {
            try
            {
                var channel = connection.CreateModel();
                channel.QueueDeclare(queue: queue,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                return channel;
            }
            catch (BrokerUnreachableException e)
            {
                Console.WriteLine($"RabbitMQ server is unreachable: {e.Message}");
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine($"Establishing a connection with RabbitMQ failed. Exception: {e.Message}");
                return null;
            }
        }
    }
}
