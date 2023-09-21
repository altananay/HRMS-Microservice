using Application.Features.JobSeekers.Dtos;
using Application.Features.JobSeekers.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobSeekers.Queries.GetById;

public class GetByIdJobSeekerQuery : IRequest<GetByIdJobSeekerResponse>
{
    public Guid Id { get; set; }

    public class GetByIdJobSeekerQueryHandler : IRequestHandler<GetByIdJobSeekerQuery, GetByIdJobSeekerResponse>
    {
        private readonly IJobSeekerRepository _jobSeekerRepository;
        private readonly IMapper _mapper;
        private readonly JobSeekerBusinessRules _jobSeekerBusinessRules;

        public GetByIdJobSeekerQueryHandler(IJobSeekerRepository jobSeekerRepository, IMapper mapper, JobSeekerBusinessRules jobSeekerBusinessRules)
        {
            _jobSeekerRepository = jobSeekerRepository;
            _mapper = mapper;
            _jobSeekerBusinessRules = jobSeekerBusinessRules;
        }

        public async Task<GetByIdJobSeekerResponse> Handle(GetByIdJobSeekerQuery request, CancellationToken cancellationToken)
        {
            await _jobSeekerBusinessRules.CheckIfJobSeekerExists(request.Id);
            JobSeeker? jobSeeker = await _jobSeekerRepository.GetAsync(predicate: js => js.Id == request.Id);

            GetByIdJobSeekerResponse response = _mapper.Map<GetByIdJobSeekerResponse>(jobSeeker);
            return response;
        }
    }
}