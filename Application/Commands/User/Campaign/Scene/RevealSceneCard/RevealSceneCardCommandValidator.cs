using FluentValidation;

namespace Application.Commands.User.Campaign.Scene.RevealSceneCard;

public class RevealSceneCardCommandValidator : AbstractValidator<RevealSceneCardCommand>
{
    public RevealSceneCardCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}