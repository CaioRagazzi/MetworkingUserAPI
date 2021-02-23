namespace MetWorkingUserInfrastructure.Broker
{
    using System;
    using System.Text;
    using MetWorkingUserApplication.Interfaces.Broker;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using RabbitMQ.Client.Events;

    public class RabbitMqBroker : IBroker
    {
        private IConnection Connection { get; set; }

        public RabbitMqBroker()
        {
            Connect("amqp://guest:guest@rabbitmq:5672");
            Consumer("boost-user");
        }
        
        public void Connect(string connectionString)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri(connectionString)
            };

            Connection = factory.CreateConnection();
        }

        public byte[] CreateMessage<T>(T message)
        {
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));

            return body;
        }

        public void Publish(byte[] message, string queue)
        {
            var channel = Connection.CreateModel();
            channel.QueueDeclare(queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);
            
            channel.BasicPublish("", queue, null, message);
        }

        public void Consumer(string queue)
        {
            var channel = Connection.CreateModel();
            channel.QueueDeclare(queue,
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            string message = null;
            consumer.Received += (_, e) =>
            {
                var body = e.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                Console.Out.WriteLine(message);
            };
            channel.BasicConsume(queue, true, consumer);
        }
    }
}