using FluentValidation;

namespace Application.Commands.User.User.FriendRequests.AcceptFriendRequest;

public class AcceptFriendRequestCommandValidator : AbstractValidator<AcceptFriendRequestCommand>
{
    public AcceptFriendRequestCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}