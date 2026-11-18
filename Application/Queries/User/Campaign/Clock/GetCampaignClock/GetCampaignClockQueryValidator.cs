using FluentValidation;

namespace Application.Queries.User.Campaign.Clock.GetCampaignClock;

public class GetCampaignClockQueryValidator : AbstractValidator<GetCampaignClockQuery>
{
    public GetCampaignClockQueryValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
    }
}
