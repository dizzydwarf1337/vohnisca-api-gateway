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
        var result = await _userRpcClient.GetFriendRequests(request.Token);
        return result is { IsSuccess: true, Data.FriendRequests: not null }
            ? ApiResponse<FriendRequest[]>.Success(result.Data.FriendRequests)
            : ApiResponse<FriendRequest[]>.Failure(result.Error ?? "Error while loading friend requests");
    }
}