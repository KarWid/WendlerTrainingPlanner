namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    using WendlerTrainingPlanner.Domain.Ddd;

    public abstract class BaseUniqueId<T> : ValueObject<T> where T : ValueObject<T>
    {
        public abstract string ValueInString();

        protected abstract string GetName();

        public AggregateKey GetAggregateKey()
        {
            return new AggregateKey
            {
                Id = ValueInString(),
                Type = GetName()
            };
        }

        public BaseUniqueId()
        {

        }
    }
}
