namespace WendlerTrainingPlanner.Infrastructure.EventStoreAndBus.Repositories
{
    using WendlerTrainingPlanner.Application.EventSourcing;
    using WendlerTrainingPlanner.Application.EventSourcing.Contracts;
    using WendlerTrainingPlanner.Application.EventSourcing.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class EventRepository : IEventRepository
    {
        private readonly IEventStore _eventStore;
        private readonly IEventPublisher _eventPublisher;

        public EventRepository(IEventStore eventStore, IEventPublisher eventPublisher)
        {
            if (eventStore == null) throw new ArgumentException(nameof(eventStore));
            if (eventPublisher == null) throw new ArgumentNullException(nameof(eventPublisher));

            _eventStore = eventStore;
            _eventPublisher = eventPublisher;
        }

        public T Get<T>(AggregateKey aggregateId) where T : AggregateRoot
        {
            return LoadAggregate<T>(aggregateId);
        }

        public void Save<T>(T aggregate, int? expectedVersion = null) where T : AggregateRoot
        {
            if (expectedVersion is not null && _eventStore.Get(aggregate.Key, expectedVersion.Value).Any())
            {
                throw new ConcurrencyException(aggregate.Key);
            }

            var i = 0;
            foreach (var @event in aggregate.GetUncommittedChanges())
            {
                if (@event.Key == AggregateKey.Empty)
                {
                    @event.Key = aggregate.Key;
                }

                if (@event.Key == AggregateKey.Empty){
                    throw new AggregateOrEventMissingIdException(aggregate.GetType(), @event.GetType());
                }

                @event.Version = aggregate.Version + i++;
                @event.TimeStamp = DateTimeOffset.UtcNow;
                _eventStore.Save(@event); // TODO: to analyze it
                _eventPublisher.Publish(@event); // TODO: to analyze it
            }

            aggregate.MarkChangesAsCommitted();
        }

        private T LoadAggregate<T>(AggregateKey id) where T : AggregateRoot
        {
            var aggregate = AggregateFactory.CreateAggregate<T>();

            var events = _eventStore.Get(id, -1);
            if (!events.Any()) throw new AggregateNotFoundException(id);

            aggregate.LoadFromHistory(events);
            return aggregate;
        }
    }
}
