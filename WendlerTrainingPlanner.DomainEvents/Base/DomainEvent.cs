namespace WendlerTrainingPlanner.DomainEvents.Base
{
    using WendlerTrainingPlanner.Domain;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    // TODO: maybe to change to records
    public abstract class DomainEvent : IEvent
    {
        public AggregateKey Key { get; set; }

        public int Version { get; set; }
        public DateTimeOffset TimeStamp { get; set; }

        protected DomainEvent(DateTimeOffset occuredOn, int version)
        {
            TimeStamp = occuredOn;
            Version = version;
        }

        protected DomainEvent(int version)
        {
            TimeStamp = AppTime.UtcNow();
            Version = version;
        }

        protected DomainEvent()
        {
        }
    }
}
