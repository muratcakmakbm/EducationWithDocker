using AutoMapper;
using Education.Application.EducationGroup.Dto;
using Education.Application.EducationGroup.Queries.GetEducationGroups;
using Education.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education.Application.EducationGroup
{
    public class EducationCacheHelper
    {
        private readonly IUnitOfWork _uow;
        private readonly ICacheService _cache;
        private readonly IMapper _mapper;
        public EducationCacheHelper(IUnitOfWork uow, ICacheService cache,IMapper maapper)
        {
            _uow = uow;
            _cache = cache;
            _mapper = maapper;
        }
        public async Task UpdateCache()
        {
            List<GetEducationGroupsResult> educationGroups = null;

            var educationGroups_ = await _uow.EducationGroup.GetList();
            
            educationGroups = _mapper.Map<List<GetEducationGroupsResult>>(educationGroups_);
            
            _cache.Remove("EducationGroupList");
            
            var json = JsonConvert.SerializeObject(educationGroups);
            
            _cache.Add("EducationGroupList", json, new TimeSpan(00, 30, 0));
        }

        public async Task<List<GetEducationGroupsResult>> GetCache()
        {
            var json = _cache.Get<string>("EducationGroupList");
            
            var educationGroups = JsonConvert.DeserializeObject<List<GetEducationGroupsResult>>(json);
            
            return educationGroups;
        }
    }
}
