using FluentValidation;

namespace Application.Commands.User.Campaign.Card.ReturnItemCardToStash;

public class ReturnItemCardToStashCommandValidator : AbstractValidator<ReturnItemCardToStashCommand>
{
    public ReturnItemCardToStashCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}
