using Application.Features.Contacts.Dtos;
using Application.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.Contacts.Queries.GetList;

public class GetListContactQuery : IRequest<GetListResponse<GetListContactListItemDto>>
{
    public PageRequest PageRequest { get; set; }

    public class GetListContactQueryHandler : IRequestHandler<GetListContactQuery, GetListResponse<GetListContactListItemDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetListContactQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<GetListResponse<GetListContactListItemDto>> Handle(GetListContactQuery request, CancellationToken cancellationToken)
        {
            Paginate<Contact> contacts = await _contactRepository.GetListAsync(index: request.PageRequest.PageIndex, size: request.PageRequest.PageSize, cancellationToken: cancellationToken, enableTracking: false);

            GetListResponse<GetListContactListItemDto> response = _mapper.Map<GetListResponse<GetListContactListItemDto>>(contacts);
            return response;
        }
    }
}