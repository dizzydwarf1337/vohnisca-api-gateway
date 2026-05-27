using FluentValidation;

namespace Application.Commands.User.Campaign.Note.GrantNoteAccess;

public class GrantNoteAccessCommandValidator : AbstractValidator<GrantNoteAccessCommand>
{
    public GrantNoteAccessCommandValidator()
    {
        RuleFor(x => x.NoteId).NotEmpty();
        RuleFor(x => x.TargetUserId).NotEmpty();
    }
}