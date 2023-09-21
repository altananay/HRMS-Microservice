using Application.Features.JobSeekers.Commands.Create;
using Application.Features.JobSeekers.Commands.Delete;
using Application.Features.JobSeekers.Commands.Update;
using Application.Features.JobSeekers.Dtos;
using Application.Features.JobSeekers.Queries.GetById;
using Application.Features.JobSeekers.Queries.GetByList;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.WebAPI;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobSeekersController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateJobSeekerCommand createJobSeekerCommand)
        {
            CreatedJobSeekerResponse response = await Mediator.Send(createJobSeekerCommand);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListJobSeekerQuery getListJobSeekerQuery = new() { PageRequest = pageRequest };
            GetListResponse<GetListJobSeekerListItemDto> response = await Mediator.Send(getListJobSeekerQuery);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            GetByIdJobSeekerQuery getByIdJobSeekerQuery = new() { Id = id };
            GetByIdJobSeekerResponse response = await Mediator.Send(getByIdJobSeekerQuery);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateJobSeekerCommand updateJobSeekerCommand)
        {
            UpdatedJobSeekerResponse response = await Mediator.Send(updateJobSeekerCommand);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            DeletedJobSeekerResponse response = await Mediator.Send(new DeleteJobSeekerCommand { Id = id });
            return Ok(response);
        }
    }
}