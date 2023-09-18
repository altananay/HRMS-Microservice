namespace Application.Features.Contacts.Dtos;

public class UpdatedContactResponse
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public DateTime UpdatedDate { get; set; }
}