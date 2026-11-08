using FluentValidation;

namespace Application.Commands.User.Campaign.Stash.RejectItemTake;

public class RejectItemTakeCommandValidator : AbstractValidator<RejectItemTakeCommand>
{
    public RejectItemTakeCommandValidator()
    {
        RuleFor(x => x.RequestId).NotEmpty();
    }
}