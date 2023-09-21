using Application.Features.JobSeekers.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobSeekers.Queries.GetByList;

public class GetListJobSeekerQuery : IRequest<GetListResponse<GetListJobSeekerListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListJobSeekerQueryHandler : IRequestHandler<GetListJobSeekerQuery, GetListResponse<GetListJobSeekerListItemDto>>
    {
        private readonly IJobSeekerRepository _jobSeekerRepository;
        private readonly IMapper _mapper;

        public GetListJobSeekerQueryHandler(IJobSeekerRepository jobSeekerRepository, IMapper mapper)
        {
            _jobSeekerRepository = jobSeekerRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListJobSeekerListItemDto>> Handle(GetListJobSeekerQuery request, CancellationToken cancellationToken)
        {
            Paginate<JobSeeker> jobSeekers = await _jobSeekerRepository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, enableTracking: false);

            GetListResponse<GetListJobSeekerListItemDto> response = _mapper.Map<GetListResponse<GetListJobSeekerListItemDto>>(jobSeekers);
            return response;
        }
    }
}