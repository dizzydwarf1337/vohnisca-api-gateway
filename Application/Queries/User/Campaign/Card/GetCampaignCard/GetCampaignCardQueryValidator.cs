using FluentValidation;

namespace Application.Queries.User.Campaign.Card.GetCampaignCard;

public class GetCampaignCardQueryValidator : AbstractValidator<GetCampaignCardQuery>
{
    public GetCampaignCardQueryValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}