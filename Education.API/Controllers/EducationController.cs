using Education.Application.EducationGroup.Commands;
using Education.Application.EducationGroup.Commands.SaveEducationGroup;
using Education.Application.EducationGroup.Queries;
using Education.Application.EducationGroup.Queries.GetEducationGroups;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Education.API.Controllers
{
    [ApiController]
    [Route("api/Education")]
    public class EducationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EducationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetEducations")]
        public async Task<ActionResult> GetEducations([FromHeader] GetEducationGroupsFilter filter)
        {
            var result = await _mediator.Send(filter);
            return Ok(result);
        }

        [HttpPost("SaveEducation")]
        public async Task SaveEducation([FromHeader] SaveEducationGroupCommand command)
        {
           await _mediator.Send(command);
        }
    }
}