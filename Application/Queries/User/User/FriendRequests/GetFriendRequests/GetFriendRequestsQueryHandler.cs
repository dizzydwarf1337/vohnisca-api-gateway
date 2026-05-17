using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.User.FriendRequests.GetFriendRequests;

public class GetFriendRequestsQueryHandler : IRequestHandler<GetFriendRequestsQuery, ApiResponse<FriendRequest[]>>
{
    private readonly IUserRpcClient _userRpcClient;
    
    public GetFriendRequestsQueryHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;
    
    public async Task<ApiResponse<FriendRequest[]>> Handle(GetFriendRequestsQuery request, CancellationToken cancellationToken)
    {
        var rpcResult = await _userRpcClient.GetFriendRequests(request.Token);
        return rpcResult.ToApiResponse(x => x.Data, "Error while loading friend requests");
    }
}