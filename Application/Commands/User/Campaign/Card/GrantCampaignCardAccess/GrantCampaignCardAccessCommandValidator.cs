using FluentValidation;

namespace Application.Commands.User.Campaign.Card.GrantCampaignCardAccess;

public class GrantCampaignCardAccessCommandValidator : AbstractValidator<GrantCampaignCardAccessCommand>
{
    public GrantCampaignCardAccessCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.TargetUserId).NotEmpty();
    }
}