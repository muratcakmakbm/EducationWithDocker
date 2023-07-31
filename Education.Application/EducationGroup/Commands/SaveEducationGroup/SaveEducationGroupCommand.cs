using Education.Application.EducationGroup.Dto;
using MediatR;
using System;
using System.Collections.Generic;

namespace Education.Application.EducationGroup.Commands.SaveEducationGroup
{
    public class SaveEducationGroupCommand : IRequest<SaveEducationGroupCommandResult>
    {
        public SaveEducationGroupCommand()
        {
            Educations = new List<EducationDto>();
        }
        public int? EducationGroupId { get; set; }
        public string EducationGroupName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public List<EducationDto> Educations { get; set; }
    }
}
