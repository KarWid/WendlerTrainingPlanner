namespace WendlerTrainingPlanner.Domain.ValueObjects.Ids
{
    public class DayOfTrainingPlanTemplateId : BaseId<DayOfTrainingPlanTemplateId>/*, IComparable*/
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

        //public int CompareTo(object? obj)
        //{
        //    // TODO: What if null?
        //    if (obj == null)
        //    {
        //        var x = 5;
        //    }

        //    if (!(obj is DayOfTrainingPlanTemplateId dayOfTrainingPlanTemplateId))
        //    {
        //        throw new ArgumentException($"{obj?.GetType()} is not an {nameof(DayOfTrainingPlanTemplateId)}");
        //    }

        //    return Value.CompareTo(dayOfTrainingPlanTemplateId.Value);
        //}
    }
}
