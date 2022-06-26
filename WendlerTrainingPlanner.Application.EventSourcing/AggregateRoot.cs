namespace WendlerTrainingPlanner.Application.EventSourcing
{
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;
    using WendlerTrainingPlanner.DomainEvents.Base;
    using WendlerTrainingPlanner.Application.EventSourcing.ReflectionDynamicObjects;

    public abstract class AggregateRoot
    {
        private readonly List<DomainEvent> _changes = new List<DomainEvent>();

        public AggregateKey Key { get; protected set; }
        public int Version { get; protected set; }

        public override string ToString()
        {
            return Key.Id + Key.Type;
        }

        public IEnumerable<DomainEvent> GetUncommittedChanges()
        {
            lock (_changes)
            {
                return _changes.ToArray();
            }
        }

        public void MarkChangesAsCommitted()
        {
            lock (_changes)
            {
                Version = Version + _changes.Count;
                _changes.Clear();
            }
        }

        public void LoadFromHistory(IEnumerable<DomainEvent> history)
        {
            foreach (var e in history)
            {
                //if (e.Version != Version + 1)
                //throw new EventsOutOfOrderException(e.Key);
                ApplyChange(e, false);
            }
        }

        protected void ApplyChange(DomainEvent @event)
        {
            ApplyChange(@event, true);
        }

        private void ApplyChange(DomainEvent @event, bool isNew)
        {
            lock (_changes)
            {
                //this.AsDynamic().Apply(@event); TODO: to test that
                this.AsDynamic()?.Apply(@event);

                if (isNew)
                {
                    _changes.Add(@event);
                }
                else
                {
                    Key = @event.Key;
                    //Version++;
                }
            }
        }
    }
}
