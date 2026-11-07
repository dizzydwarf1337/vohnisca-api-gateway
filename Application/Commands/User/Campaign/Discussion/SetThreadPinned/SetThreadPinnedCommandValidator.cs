using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.SetThreadPinned;

public class SetThreadPinnedCommandValidator : AbstractValidator<SetThreadPinnedCommand>
{
    public SetThreadPinnedCommandValidator()
    {
        RuleFor(x => x.ThreadId).NotEmpty();
    }
}