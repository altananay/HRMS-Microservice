using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class JobSeekerRepository : EfRepositoryBase<JobSeeker, Guid, JobSeekerDbContext>, IJobSeekerRepository
{
    public JobSeekerRepository(JobSeekerDbContext context) : base(context)
    {
    }
}