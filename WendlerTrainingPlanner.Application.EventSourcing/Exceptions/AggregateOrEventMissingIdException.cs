namespace WendlerTrainingPlanner.Application.EventSourcing.Exceptions
{
    using WendlerTrainingPlanner.Domain;

    public class AggregateOrEventMissingIdException : Exception
    {
        public AggregateOrEventMissingIdException(Type aggregateType, Type eventType)
            :base(string.Format(DomainResource.ExceptionMessageAggregateOrEventMissingId, eventType.FullName, aggregateType.FullName))
        {
        }
    }
}
