using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Note.CreateNote;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    public CreateNoteCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Content).MaximumLength(100000);
        RuleFor(x => x.ContentFormat).Must(ContentFormats.IsKnown)
            .WithMessage("ContentFormat must be 'text' or 'html'.");
    }
}