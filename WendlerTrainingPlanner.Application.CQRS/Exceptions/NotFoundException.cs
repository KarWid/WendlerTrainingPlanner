namespace WendlerTrainingPlanner.Application.CQRS.Exceptions
{
    public class NotFoundException : ManagerException
    {
        public NotFoundException(string message) : base(message) { }
    }
}
