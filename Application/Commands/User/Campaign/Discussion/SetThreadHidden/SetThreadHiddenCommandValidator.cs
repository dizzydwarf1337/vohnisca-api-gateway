using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.SetThreadHidden;

public class SetThreadHiddenCommandValidator : AbstractValidator<SetThreadHiddenCommand>
{
    public SetThreadHiddenCommandValidator()
    {
        RuleFor(x => x.ThreadId).NotEmpty();
    }
}