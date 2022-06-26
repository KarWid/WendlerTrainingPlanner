namespace WendlerTrainingPlanner.Application.CQRS.Mapper.Dto
{
    using AutoMapper;
    using WendlerTrainingPlanner.Application.CQRS.TrainingPlanTemplates.Commands.CreateTrainingPlanTemplate;
    using WendlerTrainingPlanner.Domain.Entities;
    using WendlerTrainingPlanner.Domain.ValueObjects;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
        }
    }
}
