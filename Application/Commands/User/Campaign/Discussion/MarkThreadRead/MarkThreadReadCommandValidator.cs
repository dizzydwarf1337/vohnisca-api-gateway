using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.MarkThreadRead;

public class MarkThreadReadCommandValidator : AbstractValidator<MarkThreadReadCommand>
{
    public MarkThreadReadCommandValidator()
    {
        RuleFor(x => x.ThreadId).NotEmpty();
    }
}