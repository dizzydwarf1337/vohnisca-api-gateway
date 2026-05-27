using FluentValidation;

namespace Application.Commands.User.Campaign.Chapter.ReorderChapters;

public class ReorderChaptersCommandValidator : AbstractValidator<ReorderChaptersCommand>
{
    public ReorderChaptersCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.OrderedIds).NotEmpty();
    }
}