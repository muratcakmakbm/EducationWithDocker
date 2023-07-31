using Education.Application.EducationGroup.Dto;
using System;
using System.Collections.Generic;

namespace Education.Application.EducationGroup.Queries.GetEducationGroups
{
    public class GetEducationGroupsResult
    {
        public GetEducationGroupsResult()
        {
            EducationGroups = new List<EducationGroup>();
        }
        public List<EducationGroup> EducationGroups { get; set; }
        public class EducationGroup 
        {
            public int? EducationGroupId { get; set; }
            public string EducationGroupName { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Status { get; set; }
            public List<EducationDto> Educations { get; set; }
        }
    }
}
