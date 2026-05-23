using Application.Core.ApiResponse;
using Application.Core.Responses;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.User.Friends.GetFriends;

public class GetFriendsQueryHandler : IRequestHandler<GetFriendsQuery, ApiResponse<PaginationResponse<Friend>>>
{
    private readonly IUserRpcClient _userRpcClient;

    public GetFriendsQueryHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<PaginationResponse<Friend>>> Handle(GetFriendsQuery request,
        CancellationToken cancellationToken)
    {
        var result = await _userRpcClient.GetFriends(request.Pagination, request.Token);
        return result.ToApiResponse(x => x.Data, "Error while loading friends");
    }
}