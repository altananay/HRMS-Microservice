using Core.Persistence.Repositories;

namespace Domain.Entities;

public class JobSeeker : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
}