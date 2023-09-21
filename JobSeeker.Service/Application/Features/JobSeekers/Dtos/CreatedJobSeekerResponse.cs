namespace Application.Features.JobSeekers.Dtos;

public class CreatedJobSeekerResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedDate { get; set; }
}