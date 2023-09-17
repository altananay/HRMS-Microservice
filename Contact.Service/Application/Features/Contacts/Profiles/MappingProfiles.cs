using Application.Features.Contacts.Commands.Create;
using Application.Features.Contacts.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Contacts.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Contact, CreateContactCommand>().ReverseMap();
        CreateMap<Contact, CreatedContactResponse>().ReverseMap();
    }
}