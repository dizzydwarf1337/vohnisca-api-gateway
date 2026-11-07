using FluentValidation;

namespace Application.Queries.User.Campaign.Card.ListItemCards;

public class ListItemCardsQueryValidator : AbstractValidator<ListItemCardsQuery>
{
    public ListItemCardsQueryValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.Page).GreaterThan(0);
        RuleFor(x => x.PageSize).InclusiveBetween(1, 200);
    }
}