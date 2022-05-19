namespace WendlerTrainingPlanner.DomainEvents.Base
{
    public interface IEvent : IMessage
    {
        public int Version { get; set; }
        DateTimeOffset TimeStamp { get; set; }
    }
}
