namespace WendlerTrainingPlanner.Domain.ValueObjects.AccessoryExercise
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;

    public class AccessoryExercises : ValueObject<AccessoryExercises>
    {
        public IEnumerable<BaseAccessoryExercise> Value { get; }

        public AccessoryExercises(IEnumerable<BaseAccessoryExercise> value)
        {
            if (value is null || !value.Any()) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "AccessoryExercises");

            var uniqueOrderNumbers = new HashSet<int>(value.Select(_ => _.OrderNumber));
            if (uniqueOrderNumbers.Count != value.Count())
            {
                throw new DomainArgumentException(DomainResource.ExercisesIncorrectOrder);
            }

            Value = value;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
