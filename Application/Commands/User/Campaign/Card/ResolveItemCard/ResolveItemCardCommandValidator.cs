using FluentValidation;

namespace Application.Commands.User.Campaign.Card.ResolveItemCard;

public class ResolveItemCardCommandValidator : AbstractValidator<ResolveItemCardCommand>
{
    public ResolveItemCardCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}
