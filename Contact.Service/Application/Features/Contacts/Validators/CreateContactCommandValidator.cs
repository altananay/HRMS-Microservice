using Application.Features.Contacts.Commands.Create;
using FluentValidation;

namespace Application.Features.Contacts.Validators;

public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
{
    public CreateContactCommandValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.Message).NotEmpty();
        RuleFor(c => c.Subject).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
    }
}