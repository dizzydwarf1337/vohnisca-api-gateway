using FluentValidation;

namespace Application.Commands.User.Campaign.Card.DestroyItemCard;

public class DestroyItemCardCommandValidator : AbstractValidator<DestroyItemCardCommand>
{
    public DestroyItemCardCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}
