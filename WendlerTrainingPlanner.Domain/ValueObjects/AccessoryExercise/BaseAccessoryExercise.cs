namespace WendlerTrainingPlanner.Domain.ValueObjects.AccessoryExercise
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;

    public abstract class BaseAccessoryExercise : ValueObject<BaseAccessoryExercise>
    {
        public int Sets { get; }
        public int OrderNumber { get; }

        public BaseAccessoryExercise(int sets, int orderNumber)
        {
            if (sets <= 0) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Sets");
            if (orderNumber <= 0) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "OrderNumber");

            OrderNumber = orderNumber;
            Sets = sets;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Sets;
            yield return OrderNumber;
        }
    }
}
