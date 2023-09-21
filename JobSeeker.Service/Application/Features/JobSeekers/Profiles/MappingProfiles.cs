using Application.Features.JobSeekers.Commands.Create;
using Application.Features.JobSeekers.Commands.Delete;
using Application.Features.JobSeekers.Commands.Update;
using Application.Features.JobSeekers.Dtos;
using AutoMapper;
using Core.Application.Responses;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.JobSeekers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<JobSeeker, CreatedJobSeekerResponse>().ReverseMap();
        CreateMap<JobSeeker, UpdatedJobSeekerResponse>().ReverseMap();
        CreateMap<JobSeeker, DeletedJobSeekerResponse>().ReverseMap();
        CreateMap<JobSeeker, UpdateJobSeekerCommand>().ReverseMap();
        CreateMap<JobSeeker, CreateJobSeekerCommand>().ReverseMap();
        CreateMap<JobSeeker, DeleteJobSeekerCommand>().ReverseMap();
        CreateMap<Paginate<JobSeeker>, GetListResponse<GetListJobSeekerListItemDto>>().ReverseMap();
        CreateMap<JobSeeker, GetByIdJobSeekerResponse>().ReverseMap();
        CreateMap<JobSeeker, GetListJobSeekerListItemDto>().ReverseMap();
    }
}