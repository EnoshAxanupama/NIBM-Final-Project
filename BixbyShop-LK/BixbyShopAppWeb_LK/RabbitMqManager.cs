using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BixbyShopAppWeb_LK
{
    public class RabbitMqManager
    {
        private static IConnection _connection;
        private static IModel _channel;

        public static void Start()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost", // Replace with your RabbitMQ server's hostname
                UserName = "guest",     // Replace with your RabbitMQ username
                Password = "guest"      // Replace with your RabbitMQ password
            };

            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            // Create a topic exchange
            _channel.ExchangeDeclare("server_hub", ExchangeType.Topic);
        }

        public static void Stop()
        {
            _channel.Close();
            _connection.Close();
        }

        public static void Publish(string message, string routingKey)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish("server_hub", routingKey, null, body);
        }

        public static void Subscribe(string queueName, string routingKey, Action<string> callback)
        {
            _channel.QueueDeclare(queueName, false, false, false, null);
            _channel.QueueBind(queueName, "server_hub", routingKey);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (sender, e) =>
            {
                var body = e.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                callback(message);
            };

            _channel.BasicConsume(queueName, true, consumer);
        }
    }
}
