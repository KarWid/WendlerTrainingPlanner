namespace WendlerTrainingPlanner.Application.EventSourcing.Contracts
{
    using WendlerTrainingPlanner.DomainEvents.Base;

    public interface IEventPublisher
    {
        void Publish<T>(T domainEvent) where T : DomainEvent;
    }
}
