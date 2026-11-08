using FluentValidation;

namespace Application.Commands.User.Campaign.Card.PickItemCard;

public class PickItemCardCommandValidator : AbstractValidator<PickItemCardCommand>
{
    public PickItemCardCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.CharacterId).NotEmpty();
    }
}
