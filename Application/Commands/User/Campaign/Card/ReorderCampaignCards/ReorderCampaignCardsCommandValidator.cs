using FluentValidation;

namespace Application.Commands.User.Campaign.Card.ReorderCampaignCards;

public class ReorderCampaignCardsCommandValidator : AbstractValidator<ReorderCampaignCardsCommand>
{
    public ReorderCampaignCardsCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.OrderedIds).NotEmpty();
        RuleForEach(x => x.OrderedIds).Must(BeGuid)
            .WithMessage("OrderedIds must hold card ids.");
    }

    private static bool BeGuid(string id) => Guid.TryParse(id, out _);
}