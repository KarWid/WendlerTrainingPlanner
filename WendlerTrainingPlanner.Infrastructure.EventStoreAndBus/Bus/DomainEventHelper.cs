namespace WendlerTrainingPlanner.Infrastructure.EventStoreAndBus.Bus
{
    using WendlerTrainingPlanner.DomainEvents.Base;
    using WendlerTrainingPlanner.DomainEvents.TrainingPlanTemplate;

    public static class DomainEventHelper
    {
        public static string GetRabbitMQQueueName(this DomainEvent domainEvent)
        {
            return domainEvent switch
            {
                TrainingPlanTemplateCreatedEvent => Constant.QUEUE_TRAINING_PLAN_TEMPLATE_CREATED,
                _ => throw new NotImplementedException()
            };
        }
    }
}
