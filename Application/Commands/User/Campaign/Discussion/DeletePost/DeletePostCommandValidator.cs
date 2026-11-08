using FluentValidation;

namespace Application.Commands.User.Campaign.Discussion.DeletePost;

public class DeletePostCommandValidator : AbstractValidator<DeletePostCommand>
{
    public DeletePostCommandValidator()
    {
        RuleFor(x => x.PostId).NotEmpty();
    }
}