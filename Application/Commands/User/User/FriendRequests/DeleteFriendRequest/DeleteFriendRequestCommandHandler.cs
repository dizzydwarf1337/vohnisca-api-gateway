using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.DeleteFriendRequest;

public class DeleteFriendRequestCommandHandler : IRequestHandler<DeleteFriendRequestCommand, ApiResponse<Unit>>
{
    private readonly IUserRpcClient _userRpcClient;

    public DeleteFriendRequestCommandHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<Unit>> Handle(DeleteFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRpcClient.DeleteFriendRequest(request.Id, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error while deleting friend request");
    }
}