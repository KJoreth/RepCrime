namespace CrimeAPI.Services
{
    public class RabbitMqSennder : IRabbitMqSennder
    {
        private IConnection? _connection;
        private IModel? _channel;
        private readonly IRabbitMqConnector _connector;
        private readonly string _queue;
        private bool _connected => _connection != null && _channel != null;


        public RabbitMqSennder(IRabbitMqConnector connector, IConfiguration config)
        {
            _queue = config["RabbitMqQueue"];
            _connector = connector;
            _connection = connector.EstablishConnection();
            if (_connection != null)
                _channel = _connector.EstablishChanel(_queue, _connection);

        }

        public void PublishMessage(string message)
        {
            if (EnsureConnection())
            {
                var body = Encoding.UTF8.GetBytes(message);

                _channel.BasicPublish(exchange: "",
                                     routingKey: _queue,
                                     basicProperties: null,
                                     body: body);
            }
        }

        private bool EnsureConnection()
        {
            if (!_connected)
            {
                _connection = _connector.EstablishConnection();
                if (_connection != null)
                    _channel = _connector.EstablishChanel(_queue, _connection);
            }

            if (!_connected)
            {
                Console.WriteLine("Connection failed");
                return false;
            }

            return true;
        }
    }
}
