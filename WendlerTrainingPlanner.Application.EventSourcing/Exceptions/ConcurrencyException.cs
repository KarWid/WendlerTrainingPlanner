namespace WendlerTrainingPlanner.Application.EventSourcing.Exceptions
{
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class ConcurrencyException : EventSourcingException
    {
        public ConcurrencyException(AggregateKey id)
            : base(string.Format("A different version than expected was found in aggregate {0}", id)) { }
    }
}
