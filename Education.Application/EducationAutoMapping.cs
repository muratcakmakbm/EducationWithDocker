using AutoMapper;
using Education.Application.EducationGroup.Commands.SaveEducationGroup;
using Education.Application.EducationGroup.Dto;
using Education.Application.EducationGroup.Queries.GetEducationGroups;
using Education.Domain.Entities;

namespace Education.Application
{
    public class EducationAutoMapping : Profile
    {
        public EducationAutoMapping()
        {
            CreateMap<tb_EducationGroup, GetEducationGroupsResult.EducationGroup>()
                .ForMember(destination => destination.Status,
                 opt => opt.MapFrom(source => GetName(source.Status))).ReverseMap();

            CreateMap<tb_EducationGroup, SaveEducationGroupCommand>().ReverseMap();

            CreateMap<tb_Education, EducationDto>().ReverseMap();
        }

        private string GetName(int? status) 
        {
            var name = ((Status)status).ToString();
            return name;
        }
    }
}
