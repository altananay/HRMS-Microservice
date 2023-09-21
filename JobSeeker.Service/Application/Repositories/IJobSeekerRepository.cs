using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IJobSeekerRepository : IAsyncRepository<JobSeeker, Guid>, IRepository<JobSeeker, Guid>
{

}