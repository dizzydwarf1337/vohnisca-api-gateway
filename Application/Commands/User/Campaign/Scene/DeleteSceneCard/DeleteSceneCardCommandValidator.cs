using FluentValidation;

namespace Application.Commands.User.Campaign.Scene.DeleteSceneCard;

public class DeleteSceneCardCommandValidator : AbstractValidator<DeleteSceneCardCommand>
{
    public DeleteSceneCardCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
    }
}