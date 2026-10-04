using FluentValidation;

namespace Application.Commands.User.Campaign.Note.SetNoteColor;

public class SetNoteColorCommandValidator : AbstractValidator<SetNoteColorCommand>
{
    public SetNoteColorCommandValidator()
    {
        RuleFor(x => x.BackgroundColor)
            .Matches("^#[0-9a-fA-F]{6}$")
            .When(x => !string.IsNullOrEmpty(x.BackgroundColor));
    }
}
