using Education.Application.EducationGroup.Queries.GetEducationGroups;
using System.Collections.Generic;

namespace Education.Application.EducationGroup.Commands.SaveEducationGroup
{
    public class SaveEducationGroupCommandResult
    {
        public List<GetEducationGroupsResult> EducationGroups { get; set; }
    }
}
