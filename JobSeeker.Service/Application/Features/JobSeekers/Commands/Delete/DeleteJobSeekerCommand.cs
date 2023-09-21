using Application.Features.JobSeekers.Dtos;
using Application.Features.JobSeekers.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobSeekers.Commands.Delete;

public class DeleteJobSeekerCommand : IRequest<DeletedJobSeekerResponse>
{
    public Guid Id { get; set; }

    public class DeleteJobSeekerCommandHandler : IRequestHandler<DeleteJobSeekerCommand, DeletedJobSeekerResponse>
    {
        private readonly IJobSeekerRepository _jobSeekerRepository;
        private readonly IMapper _mapper;
        private readonly JobSeekerBusinessRules _jobSeekerBusinessRules;

        public DeleteJobSeekerCommandHandler(IJobSeekerRepository jobSeekerRepository, IMapper mapper, JobSeekerBusinessRules jobSeekerBusinessRules)
        {
            _jobSeekerRepository = jobSeekerRepository;
            _mapper = mapper;
            _jobSeekerBusinessRules = jobSeekerBusinessRules;
        }

        public async Task<DeletedJobSeekerResponse> Handle(DeleteJobSeekerCommand request, CancellationToken cancellationToken)
        {
            await _jobSeekerBusinessRules.CheckIfJobSeekerExists(request.Id);
            JobSeeker? jobSeeker = await _jobSeekerRepository.GetAsync(js => js.Id == request.Id);
            await _jobSeekerRepository.DeleteAsync(jobSeeker);

            DeletedJobSeekerResponse response = _mapper.Map<DeletedJobSeekerResponse>(jobSeeker);
            return response;
        }
    }
}