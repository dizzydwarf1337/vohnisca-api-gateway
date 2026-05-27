using FluentValidation;

namespace Application.Commands.User.Campaign.Note.ReorderNotes;

public class ReorderNotesCommandValidator : AbstractValidator<ReorderNotesCommand>
{
    public ReorderNotesCommandValidator()
    {
        RuleFor(x => x.ChapterId).NotEmpty();
        RuleFor(x => x.OrderedIds).NotEmpty();
    }
}