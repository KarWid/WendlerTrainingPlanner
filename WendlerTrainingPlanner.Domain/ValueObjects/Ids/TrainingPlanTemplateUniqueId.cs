namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    public class TrainingPlanTemplateUniqueId : BaseUniqueId<TrainingPlanTemplateUniqueId>
    {
        public Guid Value { get; private set; }

        public TrainingPlanTemplateUniqueId()
        {
            Value = Guid.NewGuid();
        }

        public TrainingPlanTemplateUniqueId(Guid value)
        {
            Value = value;
        }

        public static TrainingPlanTemplateUniqueId NewUniqueId()
        {
            return new TrainingPlanTemplateUniqueId();
        }

        public static TrainingPlanTemplateUniqueId Empty()
        {
            return new TrainingPlanTemplateUniqueId(Guid.Empty);
        }

        public override string ValueInString() => Value.ToString();

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }

        protected override string GetName()
        {
            return "TrainingPlanTemplate";
        }
    }
}
