namespace WendlerTrainingPlanner.Application.EventSourcing.Contracts
{
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;
    using WendlerTrainingPlanner.DomainEvents.Base;

    public interface IEventStore
    {
        void Save(DomainEvent @event);
        IList<DomainEvent> Get(AggregateKey aggregateId, int fromVersion);
    }
}
