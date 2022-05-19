namespace WendlerTrainingPlanner.Domain.ValueObjects
{
    using System.Collections.Generic;
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;

    public class Weight : ValueObject<Weight>
    {
        public float Value { get; }

        public Weight(float value)
        {
            if (value <= 0)
            {
                throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Weight");
            }

            Value = value;
        }

        protected Weight() { }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
