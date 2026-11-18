using FluentValidation;

namespace Application.Commands.User.Campaign.Clock.AdvanceCampaignClock;

public class AdvanceCampaignClockCommandValidator : AbstractValidator<AdvanceCampaignClockCommand>
{
    public AdvanceCampaignClockCommandValidator()
    {
        RuleFor(x => x.CampaignId).NotEmpty();
        RuleFor(x => x.Seconds).GreaterThan(0).LessThanOrEqualTo(31_536_000);
    }
}
