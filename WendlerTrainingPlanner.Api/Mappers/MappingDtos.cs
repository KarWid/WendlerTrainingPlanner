namespace WendlerTrainingPlanner.Api.Mappers
{
    using AutoMapper;

    using ApiDtos = WendlerTrainingPlanner.Api.Contracts.Dtos;
    using CqrsDtos = WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos;

    public class MappingDtos : Profile
    {
        public MappingDtos()
        {
            CreateMap<ApiDtos.AccessoryExercise.BaseAccessoryExerciseDto, CqrsDtos.AccessoryExercise.BaseAccessoryExerciseDto>().IncludeAllDerived();
                //.Include<ApiDtos.AccessoryExercise.AccessoryExerciseDto, CqrsDtos.AccessoryExercise.AccessoryExerciseDto>()
                //.Include<ApiDtos.AccessoryExercise.SuperseriesAccessoryExerciseDto, CqrsDtos.AccessoryExercise.SuperseriesAccessoryExerciseDto>();

            CreateMap<ApiDtos.AccessoryExercise.AccessoryExerciseDto, CqrsDtos.AccessoryExercise.AccessoryExerciseDto>();
            CreateMap<ApiDtos.AccessoryExercise.AccessoryExercisesDto, CqrsDtos.AccessoryExercise.AccessoryExercisesDto>();
            CreateMap<ApiDtos.AccessoryExercise.SuperseriesAccessoryExerciseDto, CqrsDtos.AccessoryExercise.SuperseriesAccessoryExerciseDto>();
            CreateMap<ApiDtos.DayOfTrainingPlanTemplateDto, CqrsDtos.DayOfTrainingPlanTemplateDto>();
        }
    }
}
