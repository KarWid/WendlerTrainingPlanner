namespace WendlerTrainingPlanner.Domain.Entities
{
    using WendlerTrainingPlanner.Domain.Ddd;
    using WendlerTrainingPlanner.Domain.Exceptions;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class TrainingPlanTemplateType : BaseEntity<TrainingPlanTemplateTypeId>
    {
        public string Name { get; }
        public bool IsLeader { get; }

        public TrainingPlanTemplateType(string name, bool isLeader)
        {
            if (string.IsNullOrEmpty(name)) throw new DomainArgumentException(DomainResource.ArgumentNotValid, "Name");

            Name = name;
            IsLeader = isLeader;
        }
    }
}
