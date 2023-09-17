using Core.Persistence.Repositories;

namespace Domain.Entities;

public class Contact : Entity<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
}