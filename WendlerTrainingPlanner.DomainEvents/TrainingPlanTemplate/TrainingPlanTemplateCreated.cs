namespace WendlerTrainingPlanner.DomainEvents.TrainingPlanTemplate
{
    using WendlerTrainingPlanner.Domain.Entities;
    using WendlerTrainingPlanner.Domain.ValueObjects;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;
    using WendlerTrainingPlanner.DomainEvents.Base;

    // TODO
    public class TrainingPlanTemplateCreated : DomainEvent
    {
        public TrainingPlanTemplateUniqueId UniqueId { get; init; }
        public string Name { get; init; }
        public TrainingPlanTemplateTimeFrom From { get; init; } 

        public TrainingPlanTemplateCreated(
            TrainingPlanTemplateUniqueId uniqueId,
            TrainingPlanTemplateTimeFrom from,
            string name,
            int version) : base(version)
        {
            UniqueId = uniqueId;
            Key = UniqueId.GetAggregateKey();
            Name = name;
            From = from;
        }
    }
}
