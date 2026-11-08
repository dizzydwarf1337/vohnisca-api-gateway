using FluentValidation;

namespace Application.Commands.User.Campaign.Stash.ApproveItemTake;

public class ApproveItemTakeCommandValidator : AbstractValidator<ApproveItemTakeCommand>
{
    public ApproveItemTakeCommandValidator()
    {
        RuleFor(x => x.RequestId).NotEmpty();
    }
}