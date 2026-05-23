using FluentValidation;

namespace Application.Commands.User.User.FriendRequests.DeleteFriendRequest;

public class DeleteFriendRequestCommandValidator : AbstractValidator<DeleteFriendRequestCommand>
{
    public DeleteFriendRequestCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithName("Request Id");
    }
}