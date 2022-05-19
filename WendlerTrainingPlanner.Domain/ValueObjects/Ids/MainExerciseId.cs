namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    public class MainExerciseId : BaseId<MainExerciseId>
    {
        public int Value { get; }

        public MainExerciseId(int value)
        {
            Value = value;
        }

        protected MainExerciseId() { }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
