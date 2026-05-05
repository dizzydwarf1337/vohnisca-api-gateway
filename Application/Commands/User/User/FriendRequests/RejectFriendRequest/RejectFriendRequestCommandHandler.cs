using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.RejectFriendRequest;

public class RejectFriendRequestCommandHandler : IRequestHandler<RejectFriendRequestCommand, ApiResponse<Unit>>
{
    private readonly IUserRpcClient _userRpcClient;

    public RejectFriendRequestCommandHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;
    
    public async Task<ApiResponse<Unit>> Handle(RejectFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRpcClient.RejectFriendRequest(request.Id, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error while rejecting friend request");
    }
}