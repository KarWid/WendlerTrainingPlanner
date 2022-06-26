namespace WendlerTrainingPlanner.Infrastructure.EventStoreAndBus.Repositories.EventStore
{
    using System.Collections.Generic;
    using WendlerTrainingPlanner.Application.EventSourcing.Contracts;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;
    using WendlerTrainingPlanner.DomainEvents.Base;

    public class InMemoryEventStore : IEventStore
    {
        private readonly Dictionary<AggregateKey, List<DomainEvent>> _customInMemDictionary = new Dictionary<AggregateKey, List<DomainEvent>>();

        public IList<DomainEvent> Get(AggregateKey aggregateId, int fromVersion)
        {
            _customInMemDictionary.TryGetValue(aggregateId, out List<DomainEvent>? events);
            if (events != null)
            {
                return events.Where(_ => _.Version > fromVersion).ToList();
            }

            return new List<DomainEvent>();
        }

        public void Save(DomainEvent domainEvent)
        {
            _customInMemDictionary.TryGetValue(domainEvent.Key, out List<DomainEvent>? events);
            if(events == null)
            {
                events = new List<DomainEvent>();
                _customInMemDictionary.Add(domainEvent.Key, events);
            }

            events.Add(domainEvent);
        }
    }
}
