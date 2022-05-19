namespace WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate
{
    using MediatR;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class CreateTrainingPlanTemplateCommand : IRequest<CreateTrainingPlanTemplateCommandResponse>
    {
        internal int Version { get; }
        internal TrainingPlanTemplateUniqueId UniqueId { get; }

        public string Name { get; set; } = default!;
        public DateTime From { get; set; }
        public int Cycles { get; set; }
        public float TrainingMaxPercentage { get; set; }
        public int TrainingPlanTemplateTypeId { get; set; }
        public IEnumerable<DayOfTrainingPlanTemplateDto> Days { get; set; } = default!;

        public CreateTrainingPlanTemplateCommand()
        {
            Version = 0;
            UniqueId = TrainingPlanTemplateUniqueId.NewUniqueId();
        }
    }
}
