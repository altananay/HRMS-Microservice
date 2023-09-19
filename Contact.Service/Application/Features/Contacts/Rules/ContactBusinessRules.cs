using Application.Features.Contacts.Constants;
using Application.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Domain.Entities;

namespace Application.Features.Contacts.Rules;

public class ContactBusinessRules : BaseBusinessRules
{
    private readonly IContactRepository _contactRepository;

    public ContactBusinessRules(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    public async Task CheckIfContactExists(Guid id)
    {
        Contact? contact = await _contactRepository.GetAsync(predicate: c => c.Id == id);
        if (contact == null)
        {
            throw new BusinessException(ContactMessages.ContactDoesNotExists);
        }
    }
}