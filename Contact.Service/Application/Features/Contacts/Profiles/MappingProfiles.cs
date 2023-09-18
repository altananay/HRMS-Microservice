using Application.Features.Contacts.Commands.Create;
using Application.Features.Contacts.Commands.Delete;
using Application.Features.Contacts.Commands.Update;
using Application.Features.Contacts.Dtos;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Contacts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Contact, CreateContactCommand>().ReverseMap();
        CreateMap<Contact, CreatedContactResponse>().ReverseMap();
        CreateMap<Contact, UpdatedContactResponse>().ReverseMap();
        CreateMap<Contact, UpdateContactCommand>().ReverseMap();
        CreateMap<Contact, DeletedContactResponse>().ReverseMap();
        CreateMap<Contact, DeleteContactCommand>().ReverseMap();
        CreateMap<Paginate<Contact>, GetListResponse<GetListContactListItemDto>>().ReverseMap();
        CreateMap<Contact, GetListContactListItemDto>().ReverseMap();
        CreateMap<Contact, GetByIdContactResponse>().ReverseMap();
    }
}