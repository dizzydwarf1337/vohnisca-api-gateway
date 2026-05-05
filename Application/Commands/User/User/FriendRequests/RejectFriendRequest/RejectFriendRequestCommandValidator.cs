using FluentValidation;

namespace Application.Commands.User.User.FriendRequests.RejectFriendRequest;

public class RejectFriendRequestCommandValidator : AbstractValidator<RejectFriendRequestCommand>
{
    public RejectFriendRequestCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}