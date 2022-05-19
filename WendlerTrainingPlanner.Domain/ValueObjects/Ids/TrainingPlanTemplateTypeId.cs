namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    public class TrainingPlanTemplateTypeId : BaseId<TrainingPlanTemplateTypeId>
    {
        public int Value { get; }

        public TrainingPlanTemplateTypeId(int value)
        {
            Value = value;
        }

        // TODO: check if that is needed for EF
        //protected TrainingPlanTemplateTypeId() { }

        protected override IEnumerable<object> GetAttributesToIncludeInEqualityCheck()
        {
            yield return Value;
        }
    }

}
