namespace WendlerTrainingPlanner.Api.Mappers
{
    using AutoMapper;
    using WendlerTrainingPlanner.Api.Contracts.V1.Requests.TrainingPlanTemplate;
    using WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateTrainingPlanTemplateRequest, CreateTrainingPlanTemplateCommand>();
        }
    }
}
