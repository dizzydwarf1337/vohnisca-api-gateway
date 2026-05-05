using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.AcceptFriendRequest;

public class AcceptFriendRequestCommandHandler : IRequestHandler<AcceptFriendRequestCommand, ApiResponse<Unit>>
{
    private readonly IUserRpcClient _userRpcClient;
    
    public AcceptFriendRequestCommandHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;
    
    public async Task<ApiResponse<Unit>> Handle(AcceptFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRpcClient.AcceptFriendRequest(request.Id, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error while accepting friend request");
    }
}