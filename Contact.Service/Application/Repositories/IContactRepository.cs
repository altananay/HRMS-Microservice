using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories;

public interface IContactRepository : IAsyncRepository<Contact, Guid>, IRepository<Contact, Guid>
{
    
}