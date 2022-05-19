namespace WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate
{
    using AutoMapper;
    using MediatR;
    using WendlerTrainingPlanner.Application.CQRS.Exceptions;
    using WendlerTrainingPlanner.Domain.Entities;

    public class CreateTrainingPlanTemplateCommandHandler
        : IRequestHandler<CreateTrainingPlanTemplateCommand, CreateTrainingPlanTemplateCommandResponse>
    {
        private readonly IMapper _mapper;

        public CreateTrainingPlanTemplateCommandHandler(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<CreateTrainingPlanTemplateCommandResponse> Handle(
            CreateTrainingPlanTemplateCommand request, 
            CancellationToken cancellationToken)
        {
            var validator = new CreateTrainingPlanTemplateCommandValidator();

            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ManagerException(validationResult);
            }

            // TODO:
            //var trainingPlanTemplate = _mapper.Map<TrainingPlanTemplate>(request);

            return new CreateTrainingPlanTemplateCommandResponse();
        }
    }
}
