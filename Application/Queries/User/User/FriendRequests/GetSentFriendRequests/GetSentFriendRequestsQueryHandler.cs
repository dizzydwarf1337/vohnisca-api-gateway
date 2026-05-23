using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.User.FriendRequests.GetSentFriendRequests;

public class GetSentFriendRequestsQueryHandler : IRequestHandler<GetSentFriendRequestsQuery,
    ApiResponse<PaginationResponse<FriendRequest>>>
{
    private readonly IUserRpcClient _userRpcClient;

    public GetSentFriendRequestsQueryHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<PaginationResponse<FriendRequest>>> Handle(GetSentFriendRequestsQuery request,
        CancellationToken cancellationToken)
    {
        var rpcResult = await _userRpcClient.GetSentFriendRequests(request.Pagination, request.Token);
        return rpcResult.ToApiResponse(x => x.Data, "Error while loading friend requests");
    }
}