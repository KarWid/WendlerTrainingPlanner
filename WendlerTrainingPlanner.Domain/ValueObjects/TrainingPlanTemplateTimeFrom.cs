namespace WendlerTrainingPlanner.Domain.ValueObjects
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;

    public class TrainingPlanTemplateTimeFrom : ValueObject<TrainingPlanTemplateTimeFrom>
    {
        public DateTime Value { get; }

        public TrainingPlanTemplateTimeFrom(DateTime value)
        {
            if ((AppTime.UtcNow().Date - value.Date).Days < 0)
            {
                throw new DomainArgumentException(DomainResource.ArgumentDateCannotBeEarlierThanToday, "Value");
            }

            Value = value;
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
