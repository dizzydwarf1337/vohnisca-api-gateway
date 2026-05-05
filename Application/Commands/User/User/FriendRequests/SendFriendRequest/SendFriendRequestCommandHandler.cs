using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Commands.User.User.FriendRequests.SendFriendRequest;

public class SendFriendRequestCommandHandler : IRequestHandler<SendFriendRequestCommand, ApiResponse<Unit>>
{
    private readonly IUserRpcClient _userRpcClient;
    
    public SendFriendRequestCommandHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;
    
    public async Task<ApiResponse<Unit>> Handle(SendFriendRequestCommand request, CancellationToken cancellationToken)
    {
        var result = await _userRpcClient.SendFriendRequest(request.UserName, request.Token);
        return result.ToApiResponse(_ => Unit.Value, "Error while sending friend request");
    }
}