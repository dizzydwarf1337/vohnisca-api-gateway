using FluentValidation;

namespace Application.Commands.User.Campaign.Card.SetCampaignCardChapter;

public class SetCampaignCardChapterCommandValidator : AbstractValidator<SetCampaignCardChapterCommand>
{
    public SetCampaignCardChapterCommandValidator()
    {
        // A card lies in a chapter or on the campaign itself: no chapter at all means the latter.
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.ChapterId).NotEmpty().When(x => x.ChapterId.HasValue);
    }
}
