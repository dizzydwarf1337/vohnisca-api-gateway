using FluentValidation;

namespace Application.Commands.User.Campaign.Card.SetCampaignCardVisibility;

public class SetCampaignCardVisibilityCommandValidator : AbstractValidator<SetCampaignCardVisibilityCommand>
{
    public SetCampaignCardVisibilityCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}