using Application.Core.Validation;
using FluentValidation;

namespace Application.Commands.User.Campaign.Note.CreateNote;

public class CreateNoteCommandValidator : AbstractValidator<CreateNoteCommand>
{
    public CreateNoteCommandValidator()
    {
        // A note lies in a chapter or on the campaign itself; exactly one of the two names where.
        RuleFor(x => x.ChapterId).NotEmpty().When(x => x.ChapterId.HasValue);
        RuleFor(x => x.CampaignId).NotEmpty().When(x => x.CampaignId.HasValue);
        RuleFor(x => x).Must(x => x.ChapterId.HasValue ^ x.CampaignId.HasValue)
            .WithMessage("Exactly one of ChapterId or CampaignId must be set.");
        RuleFor(x => x.Title).NotEmpty().MaximumLength(255);
        RuleFor(x => x.Content).MaximumLength(100000);
        RuleFor(x => x.ContentFormat).Must(ContentFormats.IsKnown)
            .WithMessage("ContentFormat must be 'text' or 'html'.");
    }
}