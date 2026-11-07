using Application.Core.Validation;
using FluentValidation;

namespace Application.Queries.User.Campaign.Card.ListCampaignCards;

public class ListCampaignCardsQueryValidator : AbstractValidator<ListCampaignCardsQuery>
{
    public ListCampaignCardsQueryValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.Kind).Must(CardKinds.IsKnown)
            .WithMessage($"Kind must be one of {string.Join(", ", CardKinds.All)}.");
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 200);
    }
}