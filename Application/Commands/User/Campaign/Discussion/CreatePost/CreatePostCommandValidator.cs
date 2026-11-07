using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.CreatePost;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.ThreadId).NotEmpty();
        RuleFor(x => x.Body).NotEmpty().MaximumLength(10000);
    }
}