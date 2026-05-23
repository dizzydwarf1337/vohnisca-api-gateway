using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.DeleteFriendRequest;

public class DeleteFriendRequestCommand : UserRequest<Unit>
{
    public Guid Id { get; set; }
}