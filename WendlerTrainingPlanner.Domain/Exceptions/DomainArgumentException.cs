namespace WendlerTrainingPlanner.Domain.Exceptions
{
    public class DomainArgumentException : DomainException
    {
        public DomainArgumentException(string message) : base(message) { }

        public DomainArgumentException(string message, params object?[] args) : base(message, args) { }
    }
}
