using Application.Features.JobSeekers.Commands.Create;
using FluentValidation;

namespace Application.Features.JobSeekers.Validators;

public class CreateJobSeekerValidator : AbstractValidator<CreateJobSeekerCommand>
{
    public CreateJobSeekerValidator()
    {
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.FirstName).NotEmpty();
        RuleFor(c => c.LastName).NotEmpty();
        RuleFor(c => c.DateOfBirth).NotEmpty();
    }
}