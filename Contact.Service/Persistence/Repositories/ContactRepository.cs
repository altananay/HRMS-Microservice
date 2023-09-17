using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;

public class ContactRepository : EfRepositoryBase<Contact, Guid, ContactDbContext>, IContactRepository
{
    public ContactRepository(ContactDbContext context) : base(context)
    {
    }
}