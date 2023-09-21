using Application.Features.Contacts.Dtos;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Contacts.Commands.Create;

public class CreateContactCommand : IRequest<CreatedContactResponse>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, CreatedContactResponse>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public CreateContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<CreatedContactResponse> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            Contact contact = _mapper.Map<Contact>(request);
            contact.Id = Guid.NewGuid();
            await _contactRepository.AddAsync(contact);

            CreatedContactResponse response = _mapper.Map<CreatedContactResponse>(contact);
            return response;
        }
    }
}