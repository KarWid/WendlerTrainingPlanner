namespace WendlerTrainingPlanner.Application.EventSourcing
{
    using WendlerTrainingPlanner.Application.EventSourcing.Exceptions;

    public static class AggregateFactory
    {
        public static T CreateAggregate<T>()
        {
            try
            {
                return (T)Activator.CreateInstance(typeof(T), true);
            }
            catch (MissingMethodException)
            {
                throw new MissingParameterLessConstructorException(typeof(T));
            }
        }
    }
}
