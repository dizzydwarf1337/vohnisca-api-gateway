using FluentValidation;

namespace Application.Commands.User.Campaign.Card.SetItemPickable;

public class SetItemPickableCommandValidator : AbstractValidator<SetItemPickableCommand>
{
    public SetItemPickableCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        // An empty list is a valid answer: it closes the pick for everybody.
        RuleFor(x => x.UserIds).NotNull();
        RuleForEach(x => x.UserIds).NotEmpty();
    }
}
