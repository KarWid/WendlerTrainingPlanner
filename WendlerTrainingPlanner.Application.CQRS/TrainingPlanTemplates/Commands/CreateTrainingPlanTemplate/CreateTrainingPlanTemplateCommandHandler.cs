namespace WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate
{
    using AutoMapper;
    using FluentValidation;
    using MediatR;
    using WendlerTrainingPlanner.Application.Contracts.Persistance;
    using WendlerTrainingPlanner.Application.CQRS.Exceptions;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos;
    using WendlerTrainingPlanner.Application.EventSourcing.Aggregates;
    using WendlerTrainingPlanner.Application.EventSourcing.Contracts;
    using WendlerTrainingPlanner.Domain.Entities;
    using WendlerTrainingPlanner.Domain.ValueObjects;

    public class CreateTrainingPlanTemplateCommandHandler
        : IRequestHandler<CreateTrainingPlanTemplateCommand, CreateTrainingPlanTemplateCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventSourcingSession _eventSourcingSession;
        private readonly IValidator<CreateTrainingPlanTemplateCommand> _validator;
        //private readonly IRepository _repository;

        public CreateTrainingPlanTemplateCommandHandler(
            IMapper mapper, 
            IEventSourcingSession eventSourcingSession, 
            IValidator<CreateTrainingPlanTemplateCommand> validator)
            //IRepository repository)
        {
            if (mapper == null) throw new ArgumentNullException("Mapper");
            if (eventSourcingSession == null) throw new ArgumentNullException("eventSourcingSession");
            if (validator == null) throw new ArgumentNullException("Validator");
            //if (repository == null) throw new ArgumentNullException("Repository");

            _mapper = mapper;
            _eventSourcingSession = eventSourcingSession;
            _validator = validator;
            //_repository = repository;
        }

        public async Task<CreateTrainingPlanTemplateCommandResponse> Handle(
            CreateTrainingPlanTemplateCommand command, 
            CancellationToken cancellationToken)
        {
            var validationResult = await _validator.ValidateAsync(command, cancellationToken);
            if (!validationResult.IsValid)
            {
                throw new ManagerException(validationResult);
            }

            // TODO: validate TrainingPlanTemplateTypeId
            var trainingPlanTemplate = await CreateTrainingPlanTemplateAsync(command);

            //var trainingPlanTemplate = _mapper.Map<TrainingPlanTemplate>(command); // TO remove

            var trainingPlanTemplateAggregate = new TrainingPlanTemplateAggregate(trainingPlanTemplate);

            // TODO: configure eventSourcingSession
            _eventSourcingSession.Add(trainingPlanTemplateAggregate);
            _eventSourcingSession.Commit();

            var ids = _mapper.Map<IdsDto>(trainingPlanTemplate.Ids());
            return new CreateTrainingPlanTemplateCommandResponse(ids);
        }

        private async Task<TrainingPlanTemplate> CreateTrainingPlanTemplateAsync(CreateTrainingPlanTemplateCommand command)
        {
            // TODO: uncomment that
            //var trainingPlanTemplateType = _repository
            //    .FilterBy<TrainingPlanTemplateType>(_ => _.Id != null && _.Id.Value == command.TrainingPlanTemplateTypeId)
            //    .FirstOrDefault();

            //// Get training plan template type and day of training plan templates from the database
            //var dayOfTrainingPlanTemplates = command
            //    .Days
            //    .Select(_ => new DayOfTrainingPlanTemplate(_.DayOfWeek, new Weight(_.MainExerciseWeight), new MainExercise("Bench Press"), new Domain.ValueObjects.AccessoryExercise.AccessoryExercises(_.AccessoryExercises)));

            //throw new NotImplementedException();

            // TODO: remove after repository implementation

            var trainingPlanTemplateType = new TrainingPlanTemplateType("BBS Challenge", true);
            var dayOfTrainingPlanTemplates = new List<DayOfTrainingPlanTemplate>();

            return new TrainingPlanTemplate(
                command.Name,
                new TrainingPlanTemplateTimeFrom(command.From),
                new TrainingMaxPercentage(command.TrainingMaxPercentage),
                trainingPlanTemplateType,
                command.Cycles,
                dayOfTrainingPlanTemplates);
        }
    }
}
