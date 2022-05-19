namespace WendlerTrainingPlanner.Domain.Exceptions
{
    public abstract class DomainException : Exception
    {
        public DomainException(string message) : base(message) { }

        public DomainException(string message, params object?[] args) : base(string.Format(message, args)) { }
    }
}
