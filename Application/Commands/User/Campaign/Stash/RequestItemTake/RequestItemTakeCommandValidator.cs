using FluentValidation;

namespace Application.Commands.User.Campaign.Stash.RequestItemTake;

public class RequestItemTakeCommandValidator : AbstractValidator<RequestItemTakeCommand>
{
    public RequestItemTakeCommandValidator()
    {
        RuleFor(x => x.CardId).NotEmpty();
        RuleFor(x => x.CharacterId).NotEmpty();
    }
}