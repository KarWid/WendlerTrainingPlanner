namespace WendlerTrainingPlanner.DomainEvents.TrainingPlanTemplate
{
    using WendlerTrainingPlanner.Domain.Entities;
    using WendlerTrainingPlanner.Domain.ValueObjects;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;
    using WendlerTrainingPlanner.DomainEvents.Base;

    public class TrainingPlanTemplateCreatedEvent : DomainEvent
    {
        public TrainingPlanTemplateUniqueId UniqueId { get; init; }
        public string Name { get; init; }
        public TrainingPlanTemplateTimeFrom From { get; init; }
        public int Cycles { get; }
        public TrainingMaxPercentage TrainingMaxPercentage { get; }
        public TrainingPlanTemplateType Type { get; }
        public IReadOnlyCollection<DayOfTrainingPlanTemplate> Days { get; }

        public TrainingPlanTemplateCreatedEvent(
            TrainingPlanTemplateUniqueId uniqueId,
            TrainingPlanTemplateTimeFrom from,
            string name,
            int cycles,
            TrainingMaxPercentage trainingMaxPercentage,
            TrainingPlanTemplateType type,
            IReadOnlyCollection<DayOfTrainingPlanTemplate> days,
            int version) : base(version)
        {
            UniqueId = uniqueId;
            Key = UniqueId.GetAggregateKey();
            Name = name;
            From = from;
            TrainingMaxPercentage = trainingMaxPercentage;
            Type = type;
            Days = days;
            Cycles = cycles;
        }
    }
}
