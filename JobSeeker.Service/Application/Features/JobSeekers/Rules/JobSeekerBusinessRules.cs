using Application.Features.JobSeekers.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.JobSeekers.Rules;

public class JobSeekerBusinessRules : BaseBusinessRules
{
    private readonly IJobSeekerRepository _jobSeekerRepository;

    public JobSeekerBusinessRules(IJobSeekerRepository jobSeekerRepository)
    {
        _jobSeekerRepository = jobSeekerRepository;
    }

    public async Task CheckIfJobSeekerExists(Guid id)
    {
        JobSeeker? jobSeeker = await _jobSeekerRepository.GetAsync(js => js.Id == id);
        if (jobSeeker == null)
        {
            throw new BusinessException(JobSeekerMessages.JobSeekerNotExists);
        }
    }
}