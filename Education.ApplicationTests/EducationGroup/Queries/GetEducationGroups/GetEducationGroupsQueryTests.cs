using AutoMapper;
using Education.Application.EducationGroup.Tests;
using Education.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Education.Application.EducationGroup.Queries.GetEducationGroups.Tests
{
    [TestClass()]
    public class GetEducationGroupsQueryTests
    {
        private Mock<IUnitOfWork> mockUnitOfWork;
        private Mock<ICacheService> mockCacheService;
        private Mock<IMapper> mockMapper;
        private EducationCacheHelperTests educationCacheHelper;
        [TestInitialize]
        public void Init()
        {
            mockUnitOfWork = new Mock<IUnitOfWork>(MockBehavior.Strict);
            mockCacheService = new Mock<ICacheService>(MockBehavior.Strict);
            mockMapper = new Mock<IMapper>(MockBehavior.Strict);
            educationCacheHelper = new EducationCacheHelperTests();
        }

        [TestMethod()]
        public void HandleTest()
        {
            string json = string.Empty;
            List<GetEducationGroupsResult> educationGroups = null;
            mockCacheService
               .Setup(i => i.Get<string>("EducationGroupList"))
               .Returns(json)
               .Verifiable();

            if (json != null)
            {
                educationGroups = JsonConvert.DeserializeObject<List<GetEducationGroupsResult>>(json);
            }
            else
            {
                educationCacheHelper.UpdateCacheTest();
                educationCacheHelper.GetCacheTest();

            }
        }
    }
}