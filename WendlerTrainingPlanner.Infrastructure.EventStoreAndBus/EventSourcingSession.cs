namespace WendlerTrainingPlanner.Infrastructure.EventStoreAndBus
{
    using WendlerTrainingPlanner.Application.EventSourcing;
    using WendlerTrainingPlanner.Application.EventSourcing.Contracts;
    using WendlerTrainingPlanner.Application.EventSourcing.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class EventSourcingSession : IEventSourcingSession
    {
        private readonly IEventRepository _eventRepository;
        private readonly Dictionary<AggregateKey, AggregateDescriptor> _trackedAggregates;

        public EventSourcingSession(IEventRepository eventRepository)
        {
            if (eventRepository == null) { throw new ArgumentNullException("EventRepository"); }

            _eventRepository = eventRepository;
            _trackedAggregates = new Dictionary<AggregateKey, AggregateDescriptor>();
        }

        public void Add<T>(T aggregate) where T : AggregateRoot
        {
            if (!IsTracked(aggregate.Key))
            {
                _trackedAggregates.Add(
                    aggregate.Key,
                    new AggregateDescriptor
                    {
                        Aggregate = aggregate,
                        Version = aggregate.Version,
                    });
            }
            else if (_trackedAggregates[aggregate.Key].Aggregate != aggregate)
            {
                throw new ConcurrencyException(aggregate.Key);
            }
            // TODO: test it
        }

        public void Commit()
        {
            // TODO: check what if Save fails
            foreach(var descriptor in _trackedAggregates.Values)
            {
                _eventRepository.Save(descriptor.Aggregate, descriptor.Version);
            }

            _trackedAggregates.Clear();
        }

        public T Get<T>(AggregateKey id, int? expectedVersion = null) where T : AggregateRoot
        {
            // TODO: Cache should be used here instead of Dictionary - probably
            // if aggregate with valid version exists in the memory then get it from there
            if (IsTracked(id))
            {
                var trackedAggregate = (T)_trackedAggregates[id].Aggregate;
                if (expectedVersion != null && trackedAggregate.Version != expectedVersion)
                {
                    throw new ConcurrencyException(trackedAggregate.Key);
                }

                return trackedAggregate;
            }

            // get from repository and save to the memory/cache
            var aggregate = _eventRepository.Get<T>(id);
            if (expectedVersion != null && aggregate.Version != expectedVersion)
            {
                throw new ConcurrencyException(id);
            }

            Add(aggregate);

            return aggregate;
        }

        private bool IsTracked(AggregateKey id)
        {
            return _trackedAggregates.ContainsKey(id);
        }

        // TODO: To analyze it
        private class AggregateDescriptor
        {
            public AggregateRoot Aggregate { get; set; }
            public int Version { get; set; }
        }
    }
}
