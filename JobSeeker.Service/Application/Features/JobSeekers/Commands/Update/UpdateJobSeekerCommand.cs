using Application.Features.JobSeekers.Dtos;
using Application.Features.JobSeekers.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobSeekers.Commands.Update;

public class UpdateJobSeekerCommand : IRequest<UpdatedJobSeekerResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }

    public class UpdateJobSeekerCommandHandler : IRequestHandler<UpdateJobSeekerCommand, UpdatedJobSeekerResponse>
    {
        private readonly IJobSeekerRepository _jobSeekerRepository;
        private readonly IMapper _mapper;
        private readonly JobSeekerBusinessRules _jobSeekerBusinessRules;

        public UpdateJobSeekerCommandHandler(IJobSeekerRepository jobSeekerRepository, IMapper mapper, JobSeekerBusinessRules jobSeekerBusinessRules)
        {
            _jobSeekerRepository = jobSeekerRepository;
            _mapper = mapper;
            _jobSeekerBusinessRules = jobSeekerBusinessRules;
        }

        public async Task<UpdatedJobSeekerResponse> Handle(UpdateJobSeekerCommand request, CancellationToken cancellationToken)
        {
            await _jobSeekerBusinessRules.CheckIfJobSeekerExists(request.Id);
            JobSeeker? jobSeeker = await _jobSeekerRepository.GetAsync(js => js.Id == request.Id);
            jobSeeker = _mapper.Map(request, jobSeeker);
            await _jobSeekerRepository.UpdateAsync(jobSeeker);
            UpdatedJobSeekerResponse response = _mapper.Map<UpdatedJobSeekerResponse>(jobSeeker);
            return response;
        }
    }
}