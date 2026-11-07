using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.SetThreadLocked;

public class SetThreadLockedCommandValidator : AbstractValidator<SetThreadLockedCommand>
{
    public SetThreadLockedCommandValidator()
    {
        RuleFor(x => x.ThreadId).NotEmpty();
    }
}