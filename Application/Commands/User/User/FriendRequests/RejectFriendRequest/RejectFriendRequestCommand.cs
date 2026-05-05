using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.RejectFriendRequest;

public class RejectFriendRequestCommand : UserRequest<Unit>
{
    public Guid Id { get; set; }
}