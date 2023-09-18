namespace Application.Features.Contacts.Dtos;

public class DeletedContactResponse
{
    public Guid Id { get; set; }
    public DateTime DeletedDate { get; set; }
}