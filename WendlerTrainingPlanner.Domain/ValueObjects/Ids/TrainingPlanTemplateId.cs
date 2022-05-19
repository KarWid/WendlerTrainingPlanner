namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    public class TrainingPlanTemplateId : BaseId<TrainingPlanTemplateId>
    {
        public Guid Value { get; private set; }

        public TrainingPlanTemplateId() { }
        public TrainingPlanTemplateId(Guid value) { Value = value; }

        public static TrainingPlanTemplateId NewUniqueId()
        {
            return new TrainingPlanTemplateId();
        }

        public static TrainingPlanTemplateId Empty()
        {
            return new TrainingPlanTemplateId(Guid.Empty);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
