namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    public class DayOfTrainingPlanTemplateId : BaseId<DayOfTrainingPlanTemplateId>
    {
        public Guid Value { get; private set; }

        public DayOfTrainingPlanTemplateId() { }
        public DayOfTrainingPlanTemplateId(Guid value) { Value = value; }

        public static DayOfTrainingPlanTemplateId NewUniqueId()
        {
            return new DayOfTrainingPlanTemplateId();
        }

        public static DayOfTrainingPlanTemplateId Empty()
        {
            return new DayOfTrainingPlanTemplateId(Guid.Empty);
        }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }
}
