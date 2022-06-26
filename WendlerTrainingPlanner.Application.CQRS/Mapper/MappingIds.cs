namespace WendlerTrainingPlanner.Application.CQRS.Mapper
{
    using AutoMapper;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos;
    using WendlerTrainingPlanner.Domain.ValueObjects.Ids;

    public class MappingIds : Profile
    {
        public MappingIds()
        {
            CreateMap<TrainingPlanTemplateIds, IdsDto>()
                .ForMember(dest => dest.Status, opts => opts.MapFrom(src => src.Status.ToString()));

            CreateMap<TrainingPlanTemplateId, Guid>().ConstructUsing(_ => _.Value);
            CreateMap<Guid, TrainingPlanTemplateId>().ConstructUsing(id => new TrainingPlanTemplateId(id));

            CreateMap<TrainingPlanTemplateUniqueId, Guid>().ConstructUsing(_ => _.Value);
            CreateMap<Guid, TrainingPlanTemplateUniqueId>().ConstructUsing(id => new TrainingPlanTemplateUniqueId(id));
        }
    }
}
