using FluentValidation;

namespace Application.Commands.User.Campaign.Card.GiveItemCardToCharacter;

public class GiveItemCardToCharacterCommandValidator : AbstractValidator<GiveItemCardToCharacterCommand>
{
    public GiveItemCardToCharacterCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.CharacterId).NotEmpty();
    }
}
