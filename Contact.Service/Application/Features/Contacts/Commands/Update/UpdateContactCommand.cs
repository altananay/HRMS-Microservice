using Application.Features.Contacts.Dtos;
using Application.Features.Contacts.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Contacts.Commands.Update;

public class UpdateContactCommand : IRequest<UpdatedContactResponse>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }

    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdatedContactResponse>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ContactBusinessRules _contactBusinessRules;

        public UpdateContactCommandHandler(IContactRepository contactRepository, IMapper mapper, ContactBusinessRules contactBusinessRules)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _contactBusinessRules = contactBusinessRules;
        }

        public async Task<UpdatedContactResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            await _contactBusinessRules.CheckIfContactExists(request.Id);
            Contact? contact = await _contactRepository.GetAsync(c => c.Id == request.Id);
            contact = _mapper.Map(request, contact);
            await _contactRepository.UpdateAsync(contact);
            UpdatedContactResponse response = _mapper.Map<UpdatedContactResponse>(contact);
            return response;
        }
    }
}