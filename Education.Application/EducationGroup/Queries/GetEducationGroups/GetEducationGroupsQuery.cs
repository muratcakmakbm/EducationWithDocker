using AutoMapper;
using Education.Application.EducationGroup.Dto;
using Education.Domain;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
namespace Education.Application.EducationGroup.Queries.GetEducationGroups
{
    public class GetEducationGroupsQuery : IRequestHandler<GetEducationGroupsFilter, List<GetEducationGroupsResult>>
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;
        private readonly EducationCacheHelper educationCacheHelper;
        public GetEducationGroupsQuery(IUnitOfWork uow, ICacheService cache,IMapper mapper)
        {
            _uow = uow;
            _cache = cache;
            _mapper = mapper;
            educationCacheHelper = new EducationCacheHelper(_uow, _cache,_mapper);
        }
        public async Task<List<GetEducationGroupsResult>> Handle(GetEducationGroupsFilter request, CancellationToken cancellationToken)
        {
            List<GetEducationGroupsResult> educationGroups = null;
            var json = _cache.Get<string>("EducationGroupList");
            if (json != null)
            {
                educationGroups = JsonConvert.DeserializeObject<List<GetEducationGroupsResult>>(json);
            }
            else
            {
                await educationCacheHelper.UpdateCache();

                educationGroups = await educationCacheHelper.GetCache();
            }          

            return educationGroups;
        }
    }
}
