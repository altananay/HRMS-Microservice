using Application.Features.Contacts.Dtos;
using Application.Features.Contacts.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Contacts.Commands.Delete;

public class DeleteContactCommand : IRequest<DeletedContactResponse>
{
    public Guid Id { get; set; }

    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, DeletedContactResponse>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ContactBusinessRules _businessRules;

        public DeleteContactCommandHandler(IContactRepository contactRepository, IMapper mapper, ContactBusinessRules businessRules)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<DeletedContactResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.CheckIfContactExists(request.Id);
            Contact? contact = await _contactRepository.GetAsync(c => c.Id == request.Id);
            await _contactRepository.DeleteAsync(contact);
            DeletedContactResponse response = _mapper.Map<DeletedContactResponse>(contact);
            return response;
        }
    }
}