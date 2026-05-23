using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.CancelFriendRequest;

public class CancelFriendRequestCommandHandler : IRequestHandler<CancelFriendRequestCommand, ApiResponse<Unit>>
{
    private readonly IUserRpcClient _userRpcClient;

    public CancelFriendRequestCommandHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<Unit>> Handle(CancelFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRpcClient.CancelFriendRequest(request.Id, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error while canceling friend request");
    }
}