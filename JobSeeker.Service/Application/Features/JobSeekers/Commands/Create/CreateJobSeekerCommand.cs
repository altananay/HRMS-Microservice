using Application.Features.JobSeekers.Dtos;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.JobSeekers.Commands.Create;

public class CreateJobSeekerCommand : IRequest<CreatedJobSeekerResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }

    public class CreateJobSeekerCommandHandler : IRequestHandler<CreateJobSeekerCommand, CreatedJobSeekerResponse>
    {
        private readonly IJobSeekerRepository _repository;
        private readonly IMapper _mapper;

        public CreateJobSeekerCommandHandler(IJobSeekerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CreatedJobSeekerResponse> Handle(CreateJobSeekerCommand request, CancellationToken cancellationToken)
        {
            JobSeeker jobSeeker = _mapper.Map<JobSeeker>(request);
            jobSeeker.Id = Guid.NewGuid();
            jobSeeker.Status = true;
            await _repository.AddAsync(jobSeeker);

            CreatedJobSeekerResponse response = _mapper.Map<CreatedJobSeekerResponse>(jobSeeker);
            return response;
        }
    }
}