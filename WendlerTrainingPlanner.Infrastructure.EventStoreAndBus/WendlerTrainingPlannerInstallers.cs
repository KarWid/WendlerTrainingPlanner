namespace WendlerTrainingPlanner.Infrastructure.EventStoreAndBus
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using WendlerTrainingPlanner.Application.EventSourcing.Contracts;
    using WendlerTrainingPlanner.Infrastructure.EventStoreAndBus.Bus;
    using WendlerTrainingPlanner.Infrastructure.EventStoreAndBus.Repositories;
    using WendlerTrainingPlanner.Infrastructure.EventStoreAndBus.Repositories.EventStore;

    public static partial class WendlerTrainingPlannerInstallers
    {
        public static IServiceCollection AddDefaultEventStore(this IServiceCollection services)
        {
            services.AddScoped<IEventStore, InMemoryEventStore>();
            return services;
        }

        public static IServiceCollection AddBusAndRepository(
            this IServiceCollection services, 
            IConfiguration configuration)
        {
            // TODO @KWidla: services.AddOptions();
            //AddOption<RabbitMqConfiguration>(services, configuration);

            services.AddScoped<IEventSourcingSession, EventSourcingSession>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddSingleton<IEventPublisher, WendlerTrainingPlannerEventPublisher>();

            return services;
        }
    }
}
