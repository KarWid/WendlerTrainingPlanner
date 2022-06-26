using WendlerTrainingPlanner.Domain;

namespace WendlerTrainingPlanner.Application.EventSourcing.Exceptions
{
    public class MissingParameterLessConstructorException : Exception
    {
        public MissingParameterLessConstructorException(Type type)
            : base(string.Format(DomainResource.ExceptionMessageMissingParameterLessConstructorException, type.FullName)) 
        { 
        }
    }
}
