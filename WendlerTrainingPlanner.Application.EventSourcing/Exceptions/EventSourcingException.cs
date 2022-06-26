namespace WendlerTrainingPlanner.Application.EventSourcing.Exceptions
{
    public class EventSourcingException : Exception
    {
        public EventSourcingException(string message) : base(message) { }
    }
}
