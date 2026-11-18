using FluentValidation;

namespace Application.Commands.User.Campaign.Clock.ForceReleaseCampaignClock;

public class ForceReleaseCampaignClockCommandValidator : AbstractValidator<ForceReleaseCampaignClockCommand>
{
    public ForceReleaseCampaignClockCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
    }
}
