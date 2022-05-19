namespace WendlerTrainingPlanner.Domain.ValueObjects
{
    using System.Collections.Generic;
    using WendlerTrainingPlanner.Domain.Ddd;

    public class TrainingMaxPercentage : ValueObject<TrainingMaxPercentage>
    {
        public float Value { get; private set; }

        public TrainingMaxPercentage(float value)
        {
            if (value <= 0 || value > 1)
            {
                throw new ArgumentException(DomainResource.TrainingMaxPercentageNotValid);
            }

            Value = value;
        }

        protected TrainingMaxPercentage() { }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
