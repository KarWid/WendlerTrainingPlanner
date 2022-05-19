namespace WendlerTrainingPlanner.Domain.ValueObjects.AccessoryExercise
{
    using WendlerTrainingPlanner.Domain.Exceptions;

    public class SuperseriesAccessoryExercise : BaseAccessoryExercise
    {
        public AccessoryExercises AccessoryExercises { get; }

        public SuperseriesAccessoryExercise(
            int orderNumber,
            int sets,
            AccessoryExercises accessoryExercises)
            : base(sets, orderNumber)
        {
            if (accessoryExercises is null) throw new DomainArgumentException(DomainResource.ArgumentCannotBeNull, "AccessoryExercises");
            if (accessoryExercises.Value.Any(_ => _ is SuperseriesAccessoryExercise))
                throw new DomainArgumentException(DomainResource.SuperseriesAccessoryCannotHaveSuperseries);

            AccessoryExercises = accessoryExercises;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return AccessoryExercises;
            yield return base.GetAttributesToIncludeInEqualityCheck();
        }
    }
}
