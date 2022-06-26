namespace WendlerTrainingPlanner.Application.EventSourcing.Contracts
{
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public interface IEventRepository
    {
        void Save<T>(T aggregate, int? expectedVersion = null) where T : AggregateRoot;
        T Get<T>(AggregateKey aggregateId) where T : AggregateRoot;
    }
}
