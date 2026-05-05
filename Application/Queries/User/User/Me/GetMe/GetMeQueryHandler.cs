using Application.Core.ApiResponse;
using Application.Interfaces.RpcClients;
using MediatR;

namespace Application.Queries.User.User.Me.GetMe;

public class GetMeQueryHandler : IRequestHandler<GetMeQuery, ApiResponse<UserData>>
{
    private readonly IUserRpcClient _userRpcClient;

    public GetMeQueryHandler(IUserRpcClient userRpcClient)
        => _userRpcClient = userRpcClient;

    public async Task<ApiResponse<UserData>> Handle(GetMeQuery request, CancellationToken cancellationToken)
    {
        var rpcResult = await _userRpcClient.GetMe(request.Token);
        return rpcResult.ToApiResponse(data => data.Data, "Error while loading user data");
    }
}