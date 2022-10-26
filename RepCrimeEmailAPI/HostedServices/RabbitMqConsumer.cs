namespace RepCrimeEmailAPI.HostedServices
{
    public class RabbitMqConsumer : BackgroundService
    {
        private IModel? _chanel;
        private IConnection? _connection;
        private readonly IRabbitMqConnector _connector;
        private readonly string _queue;
        private readonly IEmailSender _emailSender;

        public RabbitMqConsumer(IRabbitMqConnector connector, IConfiguration config, IEmailSender emailSender)
        {
            _connector = connector;
            _queue = config["RabbitMqQueue"];
            _emailSender = emailSender;
        }


        public override Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Worker started");
            Task.Run(async () =>
            {
                while (_chanel == null)
                {
                    Console.WriteLine("Channel is null");
                    _connection = _connector.EstablishConnection();
                    if (_connection != null)
                        _chanel = _connector.EstablishChanel(_queue, _connection);

                    await Task.Delay(new TimeSpan(0, 0, 5));
                }


                _chanel.BasicQos(0, 1, false);

                return base.StartAsync(cancellationToken);
            });
            Console.WriteLine("start finished");
            return Task.CompletedTask;

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Execute");
            var consumer = new EventingBasicConsumer(_chanel);
            consumer.Received += (model, ea) =>
            {
                ConsumeMessage(ea);
            };

            _chanel.BasicConsume(queue: _queue, autoAck: true, consumer: consumer);
            return Task.CompletedTask;
        }

        private void ConsumeMessage(BasicDeliverEventArgs ea)
        {
            Console.WriteLine("send email");
            var body = ea.Body.ToArray();
            var email = Encoding.UTF8.GetString(body);
            _emailSender.SendEmail(email);
        }
    }
}
