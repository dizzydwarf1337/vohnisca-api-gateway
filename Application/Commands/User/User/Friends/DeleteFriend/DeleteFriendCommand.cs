using Application.Core.Mediatr.Requests.UserRequest;
using MediatR;

namespace Application.Commands.User.User.Friends.DeleteFriend;

public class DeleteFriendCommand : UserRequest<Unit>
{
    public Guid Id { get; set; }
}