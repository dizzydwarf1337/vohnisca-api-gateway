using FluentValidation;

namespace Application.Commands.User.Campaign.Chapter.SetCurrentChapter;

public class SetCurrentChapterCommandValidator : AbstractValidator<SetCurrentChapterCommand>
{
    public SetCurrentChapterCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.ChapterId).NotEmpty();
    }
}