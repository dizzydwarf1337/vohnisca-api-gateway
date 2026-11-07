using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.EditPost;

public class EditPostCommandValidator : AbstractValidator<EditPostCommand>
{
    public EditPostCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
        RuleFor(x => x.Body).NotEmpty().MaximumLength(10000);
    }
}