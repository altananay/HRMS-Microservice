namespace Application.Features.JobSeekers.Dtos;

public class DeletedJobSeekerResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
}