namespace WendlerTrainingPlanner.Application.EventSourcing.Contracts
{
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public interface IEventSourcingSession
    {
        // TODO: Think about result of methods
        void Add<T>(T aggregate) where T : AggregateRoot;
        T Get<T>(AggregateKey id, int? expectedVersion = null) where T : AggregateRoot;
        void Commit();
    }
}
