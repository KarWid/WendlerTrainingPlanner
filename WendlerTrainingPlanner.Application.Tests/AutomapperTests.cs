namespace WendlerTrainingPlanner.Api.Tests
{
    using System.Collections.Generic;
    using AutoMapper;
    using NUnit.Framework;
    using WendlerTrainingPlanner.Application.CQRS.Mapper;
    using WendlerTrainingPlanner.Application.CQRS.Mapper.Dto;

    public class AutomapperTests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void MappingDtosValidation()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfiles(new List<Profile>{ new MappingDtos(), new MappingProfile(), new MappingIds() }));
            config.AssertConfigurationIsValid();
        }
    }
}