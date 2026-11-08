using FluentValidation;

namespace Application.Commands.User.Campaign.Card.MoveItemCard;

public class MoveItemCardCommandValidator : AbstractValidator<MoveItemCardCommand>
{
    public MoveItemCardCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}