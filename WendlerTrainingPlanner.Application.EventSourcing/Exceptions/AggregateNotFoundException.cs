namespace WendlerTrainingPlanner.Application.EventSourcing.Exceptions
{
    using WendlerTrainingPlanner.Domain;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class AggregateNotFoundException : Exception
    {
        public AggregateNotFoundException(AggregateKey id)
            : base(string.Format(DomainResource.ExceptionMessageAggregateNotFound, id)) { }
    }
}
