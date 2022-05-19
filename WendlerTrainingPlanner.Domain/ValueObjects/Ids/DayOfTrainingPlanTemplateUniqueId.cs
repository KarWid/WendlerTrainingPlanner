namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    public class DayOfTrainingPlanTemplateUniqueId : BaseUniqueId<DayOfTrainingPlanTemplateUniqueId>
    {
        public Guid Value { get; }

        public DayOfTrainingPlanTemplateUniqueId()
        {
            Value = Guid.NewGuid();
        }

        public DayOfTrainingPlanTemplateUniqueId(Guid value)
        {
            Value = value;
        }

        public static DayOfTrainingPlanTemplateUniqueId NewUniqueId()
        {
            return new DayOfTrainingPlanTemplateUniqueId(Guid.NewGuid());
        }

        public static DayOfTrainingPlanTemplateUniqueId Empty()
        {
            return new DayOfTrainingPlanTemplateUniqueId(Guid.Empty);
        }

        public override string ValueInString() => Value.ToString();

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }

        protected override string GetName() => "DayOfTrainingPlanTemplate";
    }
}
