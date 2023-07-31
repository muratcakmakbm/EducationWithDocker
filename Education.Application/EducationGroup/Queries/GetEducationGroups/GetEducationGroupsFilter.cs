using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.EducationGroup.Queries.GetEducationGroups
{
    public class GetEducationGroupsFilter : IRequest<List<GetEducationGroupsResult>>
    {
    }
}
