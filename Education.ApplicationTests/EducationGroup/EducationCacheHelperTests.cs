using AutoMapper;
using Education.Application.EducationGroup.Dto;
using Education.Application.EducationGroup.Queries.GetEducationGroups;
using Education.Domain;
using Education.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Education.Application.EducationGroup.Tests
{
    [TestClass()]
    public class EducationCacheHelperTests
    {
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<ICacheService> mockCacheService;
        private Mock<IMapper> mockMapper;
        private Mock<IEducationGroupRepository> mockEducationGroup;
        public EducationCacheHelperTests()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            mockCacheService = new Mock<ICacheService>(MockBehavior.Strict);
            mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            mockEducationGroup = new Mock<IEducationGroupRepository>(MockBehavior.Strict);
        }

        [TestMethod()]
        public void UpdateCacheTest()
        {

            List<GetEducationGroupsResult> educationGroups = null;
            mockEducationGroup
                 .Setup(i => i.GetList(null).Result)
                .Returns(GetDummy_tb_EducationGroup());


            mockCacheService.Setup(i => i.Remove("EducationGroupList")).Verifiable();

            var json = JsonConvert.SerializeObject(educationGroups);

            mockCacheService.Setup(i => i.Add("EducationGroupList", json, new TimeSpan(00, 30, 0))).Verifiable();

            mockMapper.Setup(i => i.Map<List<GetEducationGroupsResult.EducationGroup>>(GetDummy_tb_EducationGroup())).Returns(GetDummyEducationGroups());


            mockEducationGroup.Verify(i => i.GetList(null).Result, Times.Once);
            mockCacheService.Verify(i => i.Remove("EducationGroupList"), Times.Once);
            mockCacheService.Verify(i => i.Add("EducationGroupList", json, new TimeSpan(00, 30, 0)), Times.Once);
            mockMapper.Verify(i => i.Map<List<GetEducationGroupsResult.EducationGroup>>(GetDummy_tb_EducationGroup()), Times.Once);

        }

        private List<tb_EducationGroup> GetDummy_tb_EducationGroup() 
        {
            List<tb_EducationGroup> dummytbEducationGroups = new List<tb_EducationGroup>()
            {new tb_EducationGroup(){
                EducationGroupId = 1,
                EducationGroupName = "Test",
                EndDate = new System.DateTime(2023, 7, 28, 10, 12, 14),
                StartDate = new System.DateTime(2023, 7, 28, 10, 12, 14),
                Status = 1,
                Educations = new List<tb_Education>
                {
                new tb_Education()
                {
                EducationExplanation="Test Açıklaması",
                EducationGroupId=1,
                EducationId=1,
                EducationLink="https://www.youtube.com/watch?y=eZu3IUN1hAI",
                EducationName="Test"
                }
                } }
                };
            return dummytbEducationGroups;
        }

        private List<GetEducationGroupsResult.EducationGroup> GetDummyEducationGroups() 
        {
            List<GetEducationGroupsResult.EducationGroup> dummyEducationGroups = new List<GetEducationGroupsResult.EducationGroup>()
            {new GetEducationGroupsResult.EducationGroup(){
                EducationGroupId = 1,
                EducationGroupName = "Test",
                EndDate = new System.DateTime(2023, 7, 28, 10, 12, 14),
                StartDate = new System.DateTime(2023, 7, 28, 10, 12, 14),
                Status = ((Status)1).ToString(),
                Educations = new List<EducationDto>
                {
                new EducationDto()
                {
                EducationExplanation="Test Açıklaması",
                EducationGroupId=1,
                EducationId=1,
                EducationLink="https://www.youtube.com/watch?y=eZu3IUN1hAI",
                EducationName="Test"
                }
                } }
                };

            return dummyEducationGroups;
        }


        [TestMethod()]
        public void GetCacheTest()
        {
            string json = string.Empty;

            mockCacheService.Setup(i => i.Add("EducationGroupList", json, new TimeSpan(00, 30, 0))).Verifiable();

            var educationGroups = JsonConvert.DeserializeObject<List<GetEducationGroupsResult>>(json);

            mockCacheService.Verify(i => i.Add("EducationGroupList", json, new TimeSpan(00, 30, 0)), Times.Once);

        }
    }
}