using FluentValidation;

namespace Application.Commands.User.Campaign.Card.RevokeCampaignCardAccess;

public class RevokeCampaignCardAccessCommandValidator : AbstractValidator<RevokeCampaignCardAccessCommand>
{
    public RevokeCampaignCardAccessCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.TargetUserId).NotEmpty();
    }
}