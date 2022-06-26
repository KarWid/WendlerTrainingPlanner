namespace WendlerTrainingPlanner.Application.EventSourcing.Aggregates
{
    using WendlerTrainingPlanner.Domain.Entities;
    using WendlerTrainingPlanner.Domain.ValueObjects;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;
    using WendlerTrainingPlanner.DomainEvents.TrainingPlanTemplate;

    public class TrainingPlanTemplateAggregate : AggregateRoot
    {
        public TrainingPlanTemplateUniqueId UniqueId { get; private set; }
        public string Name { get; private set; }
        public TrainingPlanTemplateTimeFrom From { get; private set; }
        public int Cycles { get; private set; }
        public TrainingMaxPercentage TrainingMaxPercentage { get; private set; }
        public TrainingPlanTemplateType Type { get; private set; }
        public IReadOnlyCollection<DayOfTrainingPlanTemplate> Days { get; private set; }

        public TrainingPlanTemplateAggregate(TrainingPlanTemplate trainingPlanTemplate)
        {
            var trainingPlanTemplateCreatedEvent = new TrainingPlanTemplateCreatedEvent(
                trainingPlanTemplate.UniqueId,
                trainingPlanTemplate.From,
                trainingPlanTemplate.Name,
                trainingPlanTemplate.Cycles,
                trainingPlanTemplate.TrainingMaxPercentage,
                trainingPlanTemplate.Type,
                trainingPlanTemplate.Days,
                trainingPlanTemplate.Version);

            ApplyChange(trainingPlanTemplateCreatedEvent);
        }

        public TrainingPlanTemplateAggregate()
        {

        }

        private void Apply(TrainingPlanTemplateCreatedEvent e)
        {
            Version = e.Version;
            Key = e.Key;
            UniqueId = e.UniqueId;
            Name = e.Name;
            From = e.From;
            Cycles = e.Cycles;
            TrainingMaxPercentage = e.TrainingMaxPercentage;
            Type = e.Type;
            Days = e.Days;
        }
    }
}
