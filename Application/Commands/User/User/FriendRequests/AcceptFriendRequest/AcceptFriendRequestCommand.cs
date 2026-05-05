using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.AcceptFriendRequest;

public class AcceptFriendRequestCommand : UserRequest<Unit>
{
    public Guid Id { get; set; }
}