namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    using WendlerTrainingPlanner.Domain.Ddd;

    public abstract class BaseId<T> : ValueObject<T> where T : ValueObject<T>
    {
        public BaseId()
        {

        }
    }
}
