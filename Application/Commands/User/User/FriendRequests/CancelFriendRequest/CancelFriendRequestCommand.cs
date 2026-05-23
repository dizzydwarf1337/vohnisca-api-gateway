using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.CancelFriendRequest;

public class CancelFriendRequestCommand : UserRequest<Unit>
{
    public Guid Id { get; set; }
}