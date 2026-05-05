using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.SendFriendRequest;

public class SendFriendRequestCommand : UserRequest<Unit>
{
    public string UserName { get; set; }
}