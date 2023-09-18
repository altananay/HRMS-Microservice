using Application.Features.Contacts.Dtos;
using Application.Features.Contacts.Rules;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Contacts.Queries.GetById;

public class GetByIdContactQuery : IRequest<GetByIdContactResponse>
{
    public Guid Id { get; set; }

    public class GetByIdContactQueryHandler : IRequestHandler<GetByIdContactQuery, GetByIdContactResponse>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        private readonly ContactBusinessRules _businessRules;

        public GetByIdContactQueryHandler(IContactRepository contactRepository, IMapper mapper, ContactBusinessRules businessRules)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<GetByIdContactResponse> Handle(GetByIdContactQuery request, CancellationToken cancellationToken)
        {
            Contact? contact = await _contactRepository.GetAsync(predicate: c => c.Id == request.Id, withDeleted: false);

            GetByIdContactResponse response = _mapper.Map<GetByIdContactResponse>(contact);
            return response;
        }
    }
}