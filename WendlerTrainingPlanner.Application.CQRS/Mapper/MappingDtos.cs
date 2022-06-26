namespace WendlerTrainingPlanner.Application.CQRS.Mapper
{
    using AutoMapper;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dtos;
    using WendlerTrainingPlanner.Domain.Entities;
    using WendlerTrainingPlanner.Domain.ValueObjects;

    public class MappingDtos : Profile
    {
        public MappingDtos()
        {
        }
    }
}
