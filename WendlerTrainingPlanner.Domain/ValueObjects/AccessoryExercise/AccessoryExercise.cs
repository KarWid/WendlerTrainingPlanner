namespace WendlerTrainingPlanner.Domain.ValueObjects.AccessoryExercise
{
    using WendlerTrainingPlanner.Domain.Exceptions;

    public class AccessoryExercise : BaseAccessoryExercise
    {
        public string Name { get; }
        public int Repetitions { get; }
        public float Weight { get; }

        public AccessoryExercise(string name, int orderNumber, int repetitions, float weight, int sets)
            : base(sets, orderNumber)
        {
            if (string.IsNullOrEmpty(name)) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Name");
            if (repetitions <= 0) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Repetitions");
            if (weight <= 0) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Weight");

            if (sets <= 0)
            {
                throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Sets");
            }

            Name = name;
            Repetitions = repetitions;
            Weight = weight;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Name;
            yield return Repetitions;
            yield return Weight;

            yield return base.GetAttributesToIncludeInEqualityCheck();
        }
    }
}
