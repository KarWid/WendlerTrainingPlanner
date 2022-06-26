namespace WendlerTrainingPlanner.Infrastructure.EventStoreAndBus.Bus
{
    using System.Text;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Newtonsoft.Json;
    using RabbitMQ.Client;
    using WendlerTrainingPlanner.Application.EventSourcing.Contracts;
    using WendlerTrainingPlanner.DomainEvents.Base;

    public class WendlerTrainingPlannerEventPublisher : IEventPublisher
    {
        //private readonly IConnectionFactory _connectionFactory;
        private readonly ConnectionFactory connectionFactory;

        public WendlerTrainingPlannerEventPublisher(IHostingEnvironment hostingEnvironment)
        {
            // TODO @KWidla: To analyze this code and change it to DI
            if (hostingEnvironment == null) throw new ArgumentNullException(nameof(hostingEnvironment));

            connectionFactory = new ConnectionFactory();

            var builder = new ConfigurationBuilder()
                .SetBasePath(hostingEnvironment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddEnvironmentVariables();

            builder.Build().GetSection("RabbitMqSetting").Bind(connectionFactory);
        }

        public void Publish<T>(T domainEvent) where T : DomainEvent
        {
            using (IConnection conn = connectionFactory.CreateConnection())
            {
                using (IModel channel = conn.CreateModel())
                {
                    var queueName = domainEvent.GetRabbitMQQueueName();

                    channel.QueueDeclare(queue: queueName, durable: false, autoDelete: false, exclusive: false, arguments: null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(domainEvent));
                    channel.BasicPublish(exchange: "", routingKey: queueName, basicProperties: null, body: body);
                }
            }
        }
    }
}
